using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class PrimaryApplicantMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new BoldRendering("Primary applicant:");

            var p = new ApplicantProcessor();
            foreach (var r in p.ProduceRenderings(application.PrimaryApplicant))
                yield return r;
        }

        public override bool Equals(object obj)
        {
            return obj is PrimaryApplicantMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 195756;
        }
    }
}
