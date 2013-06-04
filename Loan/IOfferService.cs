using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public interface IOfferService
    {
        MortgageOffer GetOffer(MortgageApplication application);
    }
}
