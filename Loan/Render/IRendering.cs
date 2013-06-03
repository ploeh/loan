using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public interface IRendering
    {
        IRenderer Accept(IRenderer renderer);
    }
}
