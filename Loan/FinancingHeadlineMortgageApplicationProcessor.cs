using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class FinancingHeadlineMortgageApplicationProcessor :
        IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new Heading2Rendering("Financing");
        }

        public override bool Equals(object obj)
        {
            return obj is FinancingHeadlineMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 1450;
        }
    }
}
