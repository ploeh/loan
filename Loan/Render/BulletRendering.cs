using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class BulletRendering : IRendering
    {
        private readonly string text;

        public BulletRendering(string text)
        {
            this.text = text;
        }

        public IRenderer Accept(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator string(BulletRendering bullet)
        {
            return bullet.text;
        }

        public static implicit operator BulletRendering(string text)
        {
            return new BulletRendering(text);
        }

        public override bool Equals(object obj)
        {
            var other = obj as BulletRendering;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.text, other.text);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
