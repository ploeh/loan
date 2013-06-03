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

            return renderings;
        }
    }
}
