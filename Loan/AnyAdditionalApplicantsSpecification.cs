using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class AnyAdditionalApplicantsSpecification : IMortgageApplicationSpecification
    {
        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return application.AdditionalApplicants.Any();
        }

        public override bool Equals(object obj)
        {
            return obj is AnyAdditionalApplicantsSpecification;
        }

        public override int GetHashCode()
        {
            return 105;
        }
    }
}
