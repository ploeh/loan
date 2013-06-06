using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    [DataContract]
    public class ConditionalMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        [DataMember]
        public IMortgageApplicationSpecification Specification;
        [DataMember]
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
