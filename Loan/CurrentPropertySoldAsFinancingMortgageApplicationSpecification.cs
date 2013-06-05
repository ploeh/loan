using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public class CurrentPropertySoldAsFinancingMortgageApplicationSpecification :
        IMortgageApplicationSpecification
    {
        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return application.CurrentPropertyWillBeSoldToFinanceNewProperty;
        }

        public override bool Equals(object obj)
        {
            return obj is CurrentPropertySoldAsFinancingMortgageApplicationSpecification;
        }

        public override int GetHashCode()
        {
            return 332918;
        }
    }
}
