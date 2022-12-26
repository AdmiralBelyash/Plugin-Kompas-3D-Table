using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;

namespace KompasApi;

/// <summary>
/// Класс обертка для взаимеодействия с api Компас 3D.
/// </summary>
public class KompasWrapper: IWrapper
{
    /// <summary>
    /// Объект Компас 3D.
    /// </summary>
    private KompasObject _kompasObject;

    /// <summary>
    /// 3D документ компаса.
    /// </summary>
    private ksDocument3D _document3D;

    /// <summary>
    /// Часть документа.
    /// </summary>
    private ksPart _part;


    /// <summary>
    /// Создание документа.
    /// </summary>
    public void CreateDocument()
    {
        if (_kompasObject == null)
        {
            var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
            _kompasObject = (KompasObject)Activator.CreateInstance(kompasType);
        }

        if (_kompasObject != null)
        {
            var retry = true;
            short attempt = 0;
            while (retry)
            {
                try
                {
                    attempt++;
                    _kompasObject.Visible = true;
                    retry = false;
                }
                catch (COMException)
                {
                    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompasObject = (KompasObject)Activator.CreateInstance(kompasType);

                    if (attempt > 3)
                    {
                        retry = false;
                    }
                }
            }

            _kompasObject.ActivateControllerAPI();
            _document3D = (ksDocument3D)_kompasObject.Document3D();
            _document3D.Create();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }
    }

    /// <summary>
    /// Создание точки на плоскости.
    /// </summary>
    /// <param name="x"> Точка по горизонтали</param>
    /// <param name="y"> Точка по вертикали</param>
    /// <returns> Точку на плоскости. </returns>
    public PointF CreatePoint(double x, double y)
    {
        return new PointF((float)x, (float)y);
    }

    /// <summary>
    /// Создание нового эскиза.
    /// </summary>
    /// <param name="n"> Плоскость</param>
    /// <returns> Объект эскиза. </returns>
    public ISketch CreateNewSketch(int n)
    {
        return new KompasSketch(_part, n);
    }

    /// <summary>
    /// Операция выдавливания эскиза.
    /// </summary>
    /// <param name="sketch"> Объект эскиза</param>
    /// <param name="distance"> Дистанция для выдавливания</param>
    /// <exception cref="TypeAccessException"></exception>
    public void Extrude(ISketch sketch, double distance)
    {
        if (!(sketch is KompasSketch kompasSketch))
        {
            throw new TypeAccessException($"Wrong sketch type." +
                                          $" Correct sketch type is {nameof(KompasSketch)}.");
        }

        kompasSketch.EndEdit();
        ksEntity extrude = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
        ksBossExtrusionDefinition extrudeDefinition = (ksBossExtrusionDefinition)extrude.GetDefinition();
        extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
        extrudeDefinition.SetSketch(kompasSketch.Sketch);
        ksExtrusionParam extrudeParam = (ksExtrusionParam)extrudeDefinition.ExtrusionParam();
        extrudeParam.depthNormal = distance;
        extrude.Create();
    }

    /// <summary>
    /// Проводит операцию скругления на ребрах.
    /// </summary>
    /// <param name="radius"> Угол скругления. </param>
    public void RoundCorners(double radius)
    {
        var roundedEdges = GetEdges();
        if (roundedEdges.Count.Equals(0))
        {
            throw new Exception("Edge collection is empty!");
        }

        var filletEntity = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_fillet);
        ksFilletDefinition filletDefinition = (ksFilletDefinition)filletEntity.GetDefinition();
        ksEntityCollection items = (ksEntityCollection)filletDefinition.array();

        filletDefinition.radius = radius;
        roundedEdges.ForEach(edge => items.Add(edge));
        filletEntity.Create();
    }

    /// <summary>
    /// Возвращает список рёбер для закругления.
    /// </summary>
    /// <returns> Список рёбер. </returns>
    public List<ksEdgeDefinition> GetEdges()
    {
        var validFaces = GetValidFaces();
        if (validFaces.Count.Equals(0))
        {
            return new List<ksEdgeDefinition>();
        }

        validFaces.Sort((face1, face2) => (
            face1.GetArea(0x1).CompareTo(face2.GetArea(0x1))
            ));

        var allEdges = new List<ksEdgeDefinition>();
        foreach (var edges in validFaces.Select(face => (ksEdgeCollection)face.EdgeCollection()))
        {
            for (var i = 0; i < edges.GetCount(); i++)
            {
                allEdges.Add((ksEdgeDefinition)edges.GetByIndex(i));
            }
        }

        allEdges.Sort((edge1, edge2) => (
            edge1.GetLength(0x1).CompareTo(edge2.GetLength(0x1))
        ));

        var shortEdges = new List<ksEdgeDefinition>();
        foreach (var edge in allEdges)
        {
            if ((int)edge.GetLength(0x1) != (int)allEdges[0].GetLength(0x1))
            {
                continue;
            }
            shortEdges.Add(edge);
        }

        return shortEdges;
    }

    /// <summary>
    /// Возвращает все валидные грани детали.
    /// </summary>
    /// <returns> Список валидных граней. </returns>
    private List<ksFaceDefinition> GetValidFaces()
    {
        var faces = GetAllFaces();
        var facesCount = faces.GetCount();
        if (facesCount == 0)
        {
            return new List<ksFaceDefinition>();
        }

        var validFaces = new List<ksFaceDefinition>();
        var i = 0;
        while (faces.Next() is not null)
        {
            var currentFace = (ksFaceDefinition)faces.GetByIndex(i);
            if (currentFace.IsValid())
            {
                validFaces.Add(currentFace);
            }

            ++i;
        }

        return validFaces;
    }

    /// <summary>
    /// Получает все поверхности твердотельного объекта документа.
    /// </summary>
    /// <returns> Список поверхностей. </returns>
    private ksFaceCollection GetAllFaces()
    {
        var body = (ksBody)_part.GetMainBody();
        var faces = (ksFaceCollection)body.FaceCollection();

        return faces;
    }
}
