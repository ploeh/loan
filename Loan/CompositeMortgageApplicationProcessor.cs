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
    public class CompositeMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        [DataMember]
        public IMortgageApplicationProcessor[] Nodes;

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            return from n in this.Nodes
                   from r in n.ProduceOffer(application)
                   select r;
        }

        public override bool Equals(object obj)
        {
            var other = obj as CompositeMortgageApplicationProcessor;
            if (other == null)
                return base.Equals(obj);

            return this.Nodes.SequenceEqual(other.Nodes);
        }

        public override int GetHashCode()
        {
            return this.Nodes
                .Select(n => n.GetHashCode())
                .Aggregate((x, y) => x ^ y);
        }
    }
}
