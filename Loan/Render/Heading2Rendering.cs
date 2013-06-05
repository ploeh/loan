using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class Heading2Rendering : IRendering
    {
        private readonly string text;

        public Heading2Rendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(Heading2Rendering heading2)
        {
            return heading2.text;
        }

        public static implicit operator Heading2Rendering(string text)
        {
            return new Heading2Rendering(text);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Heading2Rendering;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.text, other.text);
        }

        public override int GetHashCode()
        {
            return this.text.GetHashCode();
        }
    }
}
