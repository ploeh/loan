using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan
{
    public class HouseLoanApplication
    {
        public HouseLoanApplication()
        {
            this.AdditionalApplicants = new List<Applicant>();
        }

        public Applicant PrimaryApplicant { get; set; }
        public ICollection<Applicant> AdditionalApplicants { get; private set; }
        public decimal SelfPayment { get; set; }

        public Property Property { get; set; }

        public Property CurrentProperty { get; set; }
        public bool CurrentPropertyWillBeSoldToFinanceNewProperty { get; set; }

        public LoanType DesiredLoanType { get; set; }
    }
}
