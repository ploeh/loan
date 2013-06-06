using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class AndMortgageApplicationSpecification : IMortgageApplicationSpecification
    {
        [DataMember]
        public IMortgageApplicationSpecification[] Specifications;

        public bool IsSatisfiedBy(MortgageApplication application)
        {
            return this.Specifications.All(s => s.IsSatisfiedBy(application));
        }

        public override bool Equals(object obj)
        {
            var other = obj as AndMortgageApplicationSpecification;
            if (other == null)
                return base.Equals(obj);

            return this.Specifications.SequenceEqual(other.Specifications);
        }

        public override int GetHashCode()
        {
            return 667;
        }
    }
}
