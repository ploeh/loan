using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan
{
    public enum LoanType
    {
        FixedRateAnnuity = 0,
        AdjustableRateAnnuity,
        InterestOnly
    }
}
