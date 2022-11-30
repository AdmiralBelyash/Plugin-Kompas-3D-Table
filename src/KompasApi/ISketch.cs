using System.Drawing;

namespace KompasApi;

public interface ISketch
{
    public void CreateTwoPointRectangle(PointF point1, PointF point2);
}