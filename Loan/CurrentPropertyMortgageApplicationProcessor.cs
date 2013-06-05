using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class CurrentPropertyMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new TextRendering("Current property will be sold to finance new property.");
            yield return new LineBreakRendering();

            var p = new PropertyProcessor();
            foreach (var r in p.ProduceRenderings(application.CurrentProperty))
                yield return r;
        }

        public override bool Equals(object obj)
        {
            return obj is CurrentPropertyMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 19576;
        }
    }
}
