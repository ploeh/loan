using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class DateAndLocationMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public ILocationProvider LocationProvider;
        public ITimeProvider TimeProvider;
        
        public IEnumerable<IRendering> ProduceOffer(
            MortgageApplication application)
        {
            yield return new TextRendering(
                this.LocationProvider.GetCurrentLocationName() +
                ", " +
                this.TimeProvider.GetCurrentTime().ToString("D"));
            yield return new LineBreakRendering();
        }
    }
}
