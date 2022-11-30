using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasApi;

namespace CommonTestClass;

/// <summary>
/// Тестовый класс эскиза.
/// </summary>
public class TestSketch: ISketch
{
    /// <summary>
    /// Флаг создания прямоугольника.
    /// </summary>
    public bool IsCreateTwoPointRectangle { get; private set; } = false;


    /// <summary>
    /// Фейковый метод создания прямоугольника.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    public void CreateTwoPointRectangle(PointF point1, PointF point2)
    {
        IsCreateTwoPointRectangle = true;
    }
}