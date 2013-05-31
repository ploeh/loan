using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.DataCollection
{
    public class Applicant
    {
        public Contact Contact { get; set; }
        public decimal YearlyIncome { get; set; }
        public decimal Worth { get; set; }
        public string TaxationAuthority { get; set; }
    }
}
