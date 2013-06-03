using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class Heading1Rendering : IRendering
    {
        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}
