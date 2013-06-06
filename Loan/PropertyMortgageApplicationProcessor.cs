using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class PropertyMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            return new PropertyProcessor
            {
                PriceText = "Asking price"
            }
            .ProduceRenderings(application.Property);
        }

        public override bool Equals(object obj)
        {
            return obj is PropertyMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 88923;
        }
    }
}
