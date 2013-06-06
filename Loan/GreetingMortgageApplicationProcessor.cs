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
    public class GreetingMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new TextRendering(
                "Dear " +
                application.PrimaryApplicant.Contact.Name + ", " +
                application.PrimaryApplicant.Contact.Address.Street + ", " +
                application.PrimaryApplicant.Contact.Address.PostalCode + ", " +
                application.PrimaryApplicant.Contact.Address.Country);
            yield return new LineBreakRendering();

            yield return new TextRendering("It gives us great pleasure to lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            return obj is GreetingMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 3295858;
        }
    }
}
