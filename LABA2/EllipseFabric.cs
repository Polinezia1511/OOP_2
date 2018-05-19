using System.Drawing;

namespace LABA2
{
    class EllipseFabric : Fabric
    {
        public override Shape FactoryMethod(Pen pen)
        {
            return new Ellipse(pen);
        }
    }
}
