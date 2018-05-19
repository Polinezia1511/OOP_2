using System.Drawing;

namespace LABA2
{
    public abstract class Shape
    {
        public Pen pen;
         
        public Shape(Pen pen)
        { 
            this.pen = pen;
        }

        public virtual void Draw(Graphics g, Point start, Point finish) { }
    }
}
