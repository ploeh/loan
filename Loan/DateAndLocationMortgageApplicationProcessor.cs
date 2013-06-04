using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.Loan
{
    public class DateAndLocationMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<Render.IRendering> ProduceOffer(DataCollection.MortgageApplication application)
        {
            yield break;
        }
    }
}
