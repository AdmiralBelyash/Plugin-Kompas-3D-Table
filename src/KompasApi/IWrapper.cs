using System.Drawing;

namespace KompasApi;

public interface IWrapper
{
    void Extrude(ISketch sketch, double distance);

    ISketch CreateNewSketch(int n);

    PointF CreatePoint(double x, double y);

    void CreateDocument();

}