using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan
{
    public class FixedRateAnnuityOffer
    {
        public int Rate { get; set; }
        public DateTimeOffset Term { get; set; }
    }
}
