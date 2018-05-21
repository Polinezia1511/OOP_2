using System.Drawing;

namespace LABA2
{
    class Ellipse : Shape
    {
        public Ellipse(Pen pen) : base(pen) {}

        public override void Draw(Graphics g, Point start, Point finish)
        {
            g.DrawEllipse(pen, start.X, start.Y, finish.X - start.X, finish.Y - start.Y);
        }
    }
}
