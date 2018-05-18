using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing; 
using System.Threading.Tasks;

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
