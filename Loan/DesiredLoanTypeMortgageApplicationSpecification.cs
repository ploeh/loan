using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class DesiredLoanTypeMortgageApplicationSpecification :
        IMortgageApplicationSpecification
    {
        [DataMember]
        public LoanType MatchingLoanType;

        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return object.Equals(
                this.MatchingLoanType,
                application.DesiredLoanType);
        }

        public override bool Equals(object obj)
        {
            var other = obj as DesiredLoanTypeMortgageApplicationSpecification;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.MatchingLoanType, other.MatchingLoanType);
        }

        public override int GetHashCode()
        {
            return this.MatchingLoanType.GetHashCode();
        }
    }
}
