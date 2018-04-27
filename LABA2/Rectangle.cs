using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Rectangle : Shape
    {

        public override void OnChanged()
        {
            path.Reset();
            PointF[] points = new PointF[4];
            points[0] = firstPoint;
            points[2] = lastPoint;
            points[1] = new PointF(lastPoint.X, firstPoint.Y);
            points[3] = new PointF(firstPoint.X, lastPoint.Y);

            path.AddPolygon(points);
        }
    }
}
