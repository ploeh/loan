using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public class AndMortgageApplicationSpecification : IMortgageApplicationSpecification
    {
        public IList<IMortgageApplicationSpecification> Specifications;

        public AndMortgageApplicationSpecification()
        {
            this.Specifications = new List<IMortgageApplicationSpecification>();
        }

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
