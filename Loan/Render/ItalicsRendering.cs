using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class ItalicsRendering : IRendering
    {
        private readonly string text;

        public ItalicsRendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(ItalicsRendering italics)
        {
            return italics.text;
        }

        public static implicit operator ItalicsRendering(string text)
        {
            return new ItalicsRendering(text);
        }
    }
}
