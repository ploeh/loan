using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class LineBreakRendering : IRendering
    {
        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public override bool Equals(object obj)
        {
            return obj is LineBreakRendering;
        }

        public override int GetHashCode()
        {
            return 1394;
        }
    }
}
