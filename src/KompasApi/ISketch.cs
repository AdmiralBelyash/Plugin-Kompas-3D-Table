using System.Drawing;

namespace KompasApi;

/// <summary>
/// Класс эскиза.
/// </summary>
public interface ISketch
{
    /// <summary>
    /// Метод создания прямоугольника по двум точкам.
    /// </summary>
    /// <param name="point1"> Точка на плоскости. </param>
    /// <param name="point2"> Точка на плоскости. </param>
    public void CreateTwoPointRectangle(PointF point1, PointF point2);
}