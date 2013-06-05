using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class DesiredLoanMortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            yield return new Heading2Rendering("Desired loan");

            yield return new BoldRendering("Loan type:");
            yield return new TextRendering(" " + application.DesiredLoanType);
            yield return new LineBreakRendering();

            yield return new BoldRendering("Term:");
            yield return new TextRendering(" " + application.DesiredTerm + " years.");
            yield return new LineBreakRendering();

            yield return new BoldRendering("Frequency:");
            yield return new TextRendering(" " + application.DesiredFrequency);
            yield return new LineBreakRendering();
        }

        public override bool Equals(object obj)
        {
            return obj is DesiredLoanMortgageApplicationProcessor;
        }

        public override int GetHashCode()
        {
            return 57384980;
        }
    }
}
