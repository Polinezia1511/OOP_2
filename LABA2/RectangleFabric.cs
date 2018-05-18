using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class RectangleFabric : Fabric
    {
        public override Shape FactoryMethod(Pen pen)
        {
            return new Rectangle(pen);
        }
    }
}
