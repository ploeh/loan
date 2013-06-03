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
        IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            var renderings = new List<IRendering>();

            return renderings;
        }
    }
}
