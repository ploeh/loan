using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class SelfPaymentMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new BoldRendering("Self payment:");
            yield return new TextRendering(" " + application.SelfPayment);
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            return obj is SelfPaymentMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 1933;
        }
    }
}
