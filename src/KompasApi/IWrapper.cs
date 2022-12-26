using System.Drawing;
using Kompas6API5;

namespace KompasApi;

/// <summary>
/// Интерфейс апи.
/// </summary>
public interface IWrapper
{
    /// <summary>
    /// Выдавить заготовку
    /// </summary>
    /// <param name="sketch"> Эскиз сапр</param>
    /// <param name="distance"> Дистанция для выдавливания</param>
    void Extrude(ISketch sketch, double distance);

    /// <summary>
    /// Создание нового эскиза.
    /// </summary>
    /// <param name="n">Плоскость для эскиза</param>
    /// <returns> Эскиз </returns>
    ISketch CreateNewSketch(int n);

    /// <summary>
    /// Создание точки на эскизе.
    /// </summary>
    /// <param name="x"> Координата по ширине. </param>
    /// <param name="y"> Координата по высоте. </param>
    /// <returns></returns>
    PointF CreatePoint(double x, double y);

    /// <summary>
    /// Создает документ в САПР.
    /// </summary>
    void CreateDocument();

    /// <summary>
    /// Закругление граней.
    /// </summary>
    /// <param name="radius"> Радиус закругления. </param>
    public void RoundCorners(double radius);

}