using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2
{
    class Line : Shape
    {

        public override void OnChanged()
        {
            path.Reset();
            path.AddLine(firstPoint, lastPoint);
        }
    }
}
