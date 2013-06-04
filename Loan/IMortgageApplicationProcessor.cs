using System;
using System.Collections.Generic;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public interface IMortgageApplicationProcessor
    {
        IEnumerable<IRendering> ProduceOffer(MortgageApplication application);
    }
}
