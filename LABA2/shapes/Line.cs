using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Line : Shape
    {
        public Line(Pen pen) : base(pen) { }

        public override void Draw(Graphics g, Point start, Point finish)
        {
            g.DrawLine(pen, start.X, start.Y, finish.X, finish.Y);
        }
    }
}
