using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class CompositeMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public readonly IList<IMortgageApplicationProcessor> Nodes;

        public CompositeMortgageApplicationProcessor()
        {
            this.Nodes = new List<IMortgageApplicationProcessor>();
        }

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            return from n in this.Nodes
                   from r in n.ProduceOffer(application)
                   select r;
        }
    }
}
