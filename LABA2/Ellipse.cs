using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Ellipse : Shape
    {
        private SizeF size;
        public override void OnChanged()
        {
            path.Reset();
            size = new SizeF(Math.Abs(firstPoint.X - lastPoint.X), Math.Abs((firstPoint.Y - lastPoint.Y)));
            path.AddEllipse(new RectangleF(firstPoint, size));
        }
    }
}
