using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public class CurrentPropertyExistsSpecification : IMortgageApplicationSpecification
    {
        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return false;
        }
    }
}
