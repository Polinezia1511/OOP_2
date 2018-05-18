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

        public Rectangle(Pen pen) : base(pen) { }

        public override void Draw(Graphics g, Point start, Point finish)
        {
            if(finish.X < start.X || finish.Y < start.Y)
            {
                Point temp = start;
                start = finish;
                finish = temp;
            }
            g.DrawRectangle(pen, start.X, start.Y, finish.X - start.X, finish.Y - start.Y);
        }
    }
}
