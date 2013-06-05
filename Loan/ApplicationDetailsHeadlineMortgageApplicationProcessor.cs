using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class ApplicationDetailsHeadlineMortgageApplicationProcessor :
        IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new Heading1Rendering("Application details");
        }

        public override bool Equals(object obj)
        {
            return obj is ApplicationDetailsHeadlineMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 3259;
        }
    }
}
