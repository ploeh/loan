using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class ConditionalMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IMortgageApplicationSpecification Specification;
        public IMortgageApplicationProcessor TruthProcessor;

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            if (this.Specification.IsSatisfiedBy(application))
                return this.TruthProcessor.ProduceOffer(application);

            return Enumerable.Empty<IRendering>();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ConditionalMortgageApplicationProcessor;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.Specification, other.Specification)
                && object.Equals(this.TruthProcessor, other.TruthProcessor);
        }

        public override int GetHashCode()
        {
            return
                this.Specification.GetHashCode() ^
                this.TruthProcessor.GetHashCode();
        }
    }
}
