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
            this.AdditionalApplicants = new List<Contact>();
        }

        public Contact PrimaryApplicant { get; set; }
        public ICollection<Contact> AdditionalApplicants { get; private set; }

        public Property Property { get; set; }
    }
}
