using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.Render
{
    public class MarkdownRenderer : IRenderer
    {
        private readonly string markdown;

        public MarkdownRenderer()
            : this("")
        {
        }

        private MarkdownRenderer(string markdown)
        {
            this.markdown = markdown;
        }

        public IRenderer Render(BoldRendering bold)
        {
            return new MarkdownRenderer(this.markdown + "**" + bold + "**");
        }

        public IRenderer Render(BulletRendering bullet)
        {
            return new MarkdownRenderer(this.markdown + " -" + bullet + Environment.NewLine);
        }

        public IRenderer Render(Heading1Rendering heading1)
        {
            return new MarkdownRenderer(this.markdown + "# " + heading1 + " #");
        }

        public IRenderer Render(Heading2Rendering heading2)
        {
            return new MarkdownRenderer(this.markdown + "## " + heading2 + " ##");
        }

        public IRenderer Render(ItalicsRendering italics)
        {
            return new MarkdownRenderer(this.markdown + "*" + italics + "*");
        }

        public IRenderer Render(LineBreakRendering lineBreak)
        {
            return new MarkdownRenderer(this.markdown + Environment.NewLine);
        }

        public IRenderer Render(TextRendering text)
        {
            return new MarkdownRenderer(this.markdown + text);
        }
    }
}
