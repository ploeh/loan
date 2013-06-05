using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class FinancingHeadlineMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new FinancingHeadlineMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResult()
        {
            var sut = new FinancingHeadlineMortgageApplicationProcessor();

            var dummyApplication = new MortgageApplication();
            var actual = sut.ProduceOffer(dummyApplication);

            var expected = new[] 
            {
                new Heading2Rendering("Financing")
            };
            Assert.Equal(expected, actual);
        }
    }
}
