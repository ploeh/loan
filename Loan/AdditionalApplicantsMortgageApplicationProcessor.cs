using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class AdditionalApplicantsMortgageApplicationProcessor :
        IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new BoldRendering("Additional applicants:");
            yield return new LineBreakRendering();

            var p = new ApplicantProcessor();

            foreach (var a in application.AdditionalApplicants)
            {
                yield return new BulletRendering("");
                foreach (var r in p.ProduceRenderings(a))
                    yield return r;
            }
        }
    }
}
