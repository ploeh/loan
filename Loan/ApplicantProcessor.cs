using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class ApplicantProcessor
    {
        public IEnumerable<IRendering> ProduceRenderings(Applicant applicant)
        {
            yield return new TextRendering(
                " " +
                applicant.Contact.Name + ", " +
                applicant.Contact.Address.Street + ", " +
                applicant.Contact.Address.PostalCode + ", " +
                applicant.Contact.Address.Country + ". ");
            yield return new BoldRendering("Yearly income:");
            yield return new TextRendering(" " + applicant.YearlyIncome + ". ");
            yield return new BoldRendering("Tax authority:");
            yield return new TextRendering(" " + applicant.TaxationAuthority + ".");
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            return obj is ApplicantProcessor;
        }

        public override int GetHashCode()
        {
            return 19764;
        }
    }
}
