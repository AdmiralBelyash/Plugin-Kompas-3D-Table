using System.Drawing;
using Kompas6API5;

namespace KompasApi;

public interface IWrapper
{
    void Extrude(ISketch sketch, double distance);

    ISketch CreateNewSketch(int n);

    PointF CreatePoint(double x, double y);

    void CreateDocument();

    public void RoundCorners(double radius);

}