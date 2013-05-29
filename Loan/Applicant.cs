using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan
{
    public class Applicant
    {
        public Contact Contact { get; set; }
        public decimal YearlyIncome { get; set; }
        public string TaxationAuthority { get; set; }
    }
}
