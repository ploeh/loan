using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public interface IRenderer
    {
        IRenderer Render(BoldRendering bold);
        IRenderer Render(BulletRendering bullet);
        IRenderer Render(Heading1Rendering heading1);
        IRenderer Render(Heading2Rendering heading2);
        IRenderer Render(ItalicsRendering italics);
        IRenderer Render(LineBreakRendering lineBreak);
        IRenderer Render(TextRendering text);
    }
}
