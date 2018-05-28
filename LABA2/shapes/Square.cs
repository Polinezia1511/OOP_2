using System.Drawing;

namespace LABA2.shapes
{
    class Square : Shape
    { 
        public Square(Pen pen) : base(pen) {
            pen.Color = Color.LightSalmon;
            pen.Width = 4;
        }
        public override void Draw(Graphics g, Point start, Point finish)
        {
            if (finish.X < start.X || finish.Y < start.Y)
            {
                Point temp = start;
                start = finish;
                finish = temp;
            }
           g.DrawRectangle(pen, start.X, start.Y, finish.Y - start.Y, finish.Y - start.Y);
        }
    }
}

