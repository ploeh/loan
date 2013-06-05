using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class Heading1Rendering : IRendering
    {
        private readonly string text;

        public Heading1Rendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(Heading1Rendering heading1)
        {
            return heading1.text;
        }

        public static implicit operator Heading1Rendering(string text)
        {
            return new Heading1Rendering(text);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Heading1Rendering;
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
