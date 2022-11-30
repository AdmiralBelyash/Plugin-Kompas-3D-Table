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
public class KompasWrapper
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
    /// Создание документа
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
    /// <returns> Точку на плоскости</returns>
    public PointF CreatePoint(double x, double y)
    {
        return new PointF((float)x, (float)y);
    }

    /// <summary>
    /// Создание нового эскиза.
    /// </summary>
    /// <param name="n"> Плоскость</param>
    /// <returns> Объект эскиза</returns>
    public KompasSketch CreateNewSketch(int n)
    {
        return new KompasSketch(_part, n);
    }

    /// <summary>
    /// Операция выдавливания эскиза.
    /// </summary>
    /// <param name="sketch"> Объект эскиза</param>
    /// <param name="distance"> Дистанция для выдавливания</param>
    /// <exception cref="TypeAccessException"></exception>
    public void Extrude(KompasSketch sketch, double distance)
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
}
