using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Trapezium : Shape
    {
        public override void OnChanged()
        {
            PointF[] points = new PointF[4];
            points[0] = firstPoint;
            points[1] = new PointF(firstPoint.X + 20 + lastPoint.X, firstPoint.Y);
            points[2] = new PointF(lastPoint.X - 20 + firstPoint.X, lastPoint.Y);
            points[3] = lastPoint;
            path.Reset();
            path.AddPolygon(points);
        }
    }
}
