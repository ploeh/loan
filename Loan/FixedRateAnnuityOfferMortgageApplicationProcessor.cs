using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class FixedRateAnnuityOfferMortgageApplicationProcessor :
        IMortgageApplicationProcessor
    {
        public IOfferService OfferService;

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            var offer = this.OfferService.GetFixedRateAnnuityOffer(application);

            yield return new Heading2Rendering("Fixed rate offer");

            yield return new BoldRendering("Interest rate:");
            yield return new TextRendering(" " + offer.Rate / 10m + " %");
            yield return new LineBreakRendering();

            yield return new BoldRendering("Term:");
            yield return new TextRendering(" " + offer.Term.ToString("D"));
            yield return new LineBreakRendering();
        }
    }
}
