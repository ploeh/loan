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
    }
}
