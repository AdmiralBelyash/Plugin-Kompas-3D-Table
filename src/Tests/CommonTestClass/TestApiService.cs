using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasApi;

namespace CommonTestClass;

/// <summary>
/// Тестовый сервис API.
/// </summary>
public class TestApiService: IWrapper
{
    /// <summary>
    /// Флаг создания документа.
    /// </summary>
    public bool IsCreateDocument { get; private set; } = false;

    /// <summary>
    /// Флаг создания точки.
    /// </summary>
    public bool IsCreatePoint { get; private set; } = false;

    /// <summary>
    /// Флаг создания прямоугольника.
    /// </summary>
    public bool IsCreateRectangle { get; private set; } = false;

    /// <summary>
    /// Флаг создания эскиза.
    /// </summary>
    public bool IsCreateNewSketch { get; private set; } = false;

    /// <summary>
    /// Флаг выдавливания.
    /// </summary>
    public bool IsExtrude { get; private set; } = false;

    /// <summary>
    /// Флаг закругления.
    /// </summary>
    public bool IsRounded { get; private set; } = false;

   /// <summary>
   /// Создание документа.
   /// </summary>
    public void CreateDocument()
    {
        IsCreateDocument = true;
    }

   /// <summary>
    /// Создание точки
    /// </summary>
    /// <param name="x"> Координата х</param>
    /// <param name="y"> Координата y</param>
    /// <returns> Точка на плоскости </returns>
    public PointF CreatePoint(double x, double y)
    {
        IsCreatePoint = true;
        return new PointF((float)x, (float)y);
    }

    /// <summary>
    /// Создание тестового эскиза.
    /// </summary>
    /// <param name="n"></param>
    /// <returns> Тестовый эскиз </returns>
    public ISketch CreateNewSketch(int n)
    {
        IsCreateNewSketch = true;
        return new TestSketch();
    }

    /// <summary>
    /// Псевдо выдавливание.
    /// </summary>
    /// <param name="sketch"> Эскиз. </param>
    /// <param name="distance"> Дистанция для выдавливания. </param>
    public void Extrude(ISketch sketch, double distance)
    {
        IsCreateRectangle = true;
        IsExtrude = true;
    }

    public void RoundCorners(double radius)
    {
        IsRounded = true;
    }
}