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
    public class DateAndLocationMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        [DataMember]
        public ILocationProvider LocationProvider;
        [DataMember]
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

        public override bool Equals(object obj)
        {
            var other = obj as DateAndLocationMortgageApplicationProcessor;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.LocationProvider, other.LocationProvider)
                && object.Equals(this.TimeProvider, other.TimeProvider);
        }

        public override int GetHashCode()
        {
            return
                this.LocationProvider.GetHashCode() ^
                this.TimeProvider.GetHashCode();
        }
    }
}
