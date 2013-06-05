using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class TextRendering : IRendering
    {
        private readonly string text;

        public TextRendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(TextRendering text)
        {
            return text.text;
        }

        public static implicit operator TextRendering(string text)
        {
            return new TextRendering(text);
        }

        public override bool Equals(object obj)
        {
            var other = obj as TextRendering;
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
