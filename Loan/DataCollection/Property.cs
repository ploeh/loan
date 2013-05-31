using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Samples.Loan.DataCollection
{
    public class Property
    {
        public Address Address { get; set; }
        public PropertyType PropertyType { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
    }
}
