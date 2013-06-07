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
    public class RealtyUpsellMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new Heading1Rendering("Real estate services");
            yield return new TextRendering("Do you need help selling your current property? Then  lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            yield return new LineBreakRendering();
        }
    }
}
