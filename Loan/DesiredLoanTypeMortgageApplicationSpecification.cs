using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public class DesiredLoanTypeMortgageApplicationSpecification : 
        IMortgageApplicationSpecification
    {
        public LoanType MatchingLoanType;

        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return object.Equals(
                this.MatchingLoanType,
                application.DesiredLoanType);
        }
    }
}
