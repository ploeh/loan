using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class BoldRendering : IRendering
    {
        private readonly string text;

        public BoldRendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(BoldRendering bold)
        {
            return bold.text;
        }

        public static implicit operator BoldRendering(string text)
        {
            return new BoldRendering(text);
        }
    }
}
