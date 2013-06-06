using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class CurrentPropertyExistsSpecification : IMortgageApplicationSpecification
    {
        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return application.CurrentProperty != null;
        }

        public override bool Equals(object obj)
        {
            return obj is CurrentPropertyExistsSpecification;
        }

        public override int GetHashCode()
        {
            return 9861000;
        }
    }
}
