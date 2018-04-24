using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace LABA2
{
    class Shape
    {
        public GraphicsPath path = new GraphicsPath();
        public PointF firstPoint;
        public PointF lastPoint;

        public Shape()
        {

        }

        public void setFirstPoint(PointF point)
        {
            firstPoint = point;
        }
        public void setLastPoint(PointF point)
        {
            lastPoint = point;
        }

        public GraphicsPath GetPath()
        {
            return path;
        }

        public virtual void OnChanged()
        {

        }
    }
}
