using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class PropertyHeadlineMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication dummyApplication)
        {
            yield return new Heading2Rendering("Property");
        }

        public override bool Equals(object obj)
        {
            return obj is PropertyHeadlineMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 7768;
        }
    }
}
