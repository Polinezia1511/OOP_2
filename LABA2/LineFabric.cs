using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class LineFabric : Fabric
    {
        public override Shape FactoryMethod(Pen pen)
        {
            return new Line(pen);
        }
    }
}
