using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    public abstract class Fabric
    {
        public abstract Shape FactoryMethod(Pen pen);
    }
}
