using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan
{
    public class AdjustableRateAnnuityOffer
    {
        public int InitialRate { get; set; }
        public DateTimeOffset Term { get; set; }
    }
}
