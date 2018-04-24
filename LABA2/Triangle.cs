using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Triangle : Shape
    {
        public override void OnChanged()
        {
            path.Reset();
            PointF[] points = new PointF[3];
            points[0] = firstPoint;
            points[2] = lastPoint;
            points[1] = new PointF(firstPoint.X, lastPoint.Y);
            path.AddPolygon(points);
        }
    }
}
