using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.DataCollection
{
    public class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
