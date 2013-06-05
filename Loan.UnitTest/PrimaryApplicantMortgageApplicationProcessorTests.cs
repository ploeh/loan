using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class PrimaryApplicantMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new PrimaryApplicantMortgageProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }
    }
}
