using LABA2;
using Interfases;
using System.Drawing;

namespace PluginTriangle
{
    public class Triangle : Shape, IShape
    {
        public Triangle(Pen pen) : base(pen) { }

        public override void Draw(Graphics g, Point start, Point finish)
        {
            Point[] points =
            {
                start,
                new Point(start.X, finish.Y),
                finish
            };
            g.DrawPolygon(pen, points);
        }
    }

    public class TriangleFabric : Fabric, IFabric
    {
        public override Shape FactoryMethod(Pen pen)
        {
            return new Triangle(pen);
        }
    }
}


