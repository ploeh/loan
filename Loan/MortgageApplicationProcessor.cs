using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class MortgageApplicationProcessor
    {
        private readonly ILocationProvider locationProvider;
        private readonly ITimeProvider timeProvider;

        public MortgageApplicationProcessor(
            ILocationProvider locationProvider,
            ITimeProvider timeProvider)
        {
            this.locationProvider = locationProvider;
            this.timeProvider = timeProvider;
        }

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            var renderings = new List<IRendering>();

            renderings.Add(
                new TextRendering(
                    this.locationProvider.GetCurrentLocationName() +
                    ", " +
                    this.timeProvider.GetCurrentTime().ToString("D")));
            renderings.Add(new LineBreakRendering());

            renderings.Add(
                new TextRendering(
                    "Dear " +
                    application.PrimaryApplicant.Contact.Name + ", " +
                    application.PrimaryApplicant.Contact.Address.Street + ", " +
                    application.PrimaryApplicant.Contact.Address.PostalCode + ", " +
                    application.PrimaryApplicant.Contact.Address.Country));
            renderings.Add(new LineBreakRendering());

            renderings.Add(
                new TextRendering(
                    "It gives us great pleasure to lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));
            renderings.Add(new LineBreakRendering());

            return renderings;
        }
    }
}
