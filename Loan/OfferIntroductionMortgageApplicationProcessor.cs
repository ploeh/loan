using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class OfferIntroductionMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new Heading1Rendering("Loan offer");
            yield return new TextRendering("It gives us great pleasure to extend to you the following loan offer, lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            return obj is OfferIntroductionMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 130930;
        }
    }
}
