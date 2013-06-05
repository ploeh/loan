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
    public class SelfPaymentMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new SelfPaymentMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData(14000)]
        [InlineData(195)]
        public void ProduceOfferReturnsCorrectResult(int selfPayment)
        {
            var sut = new SelfPaymentMortgageApplicationProcessor();
            var application = new MortgageApplication
            {
                SelfPayment = selfPayment
            };

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new BoldRendering("Self payment:"),
                new TextRendering(" " + application.SelfPayment),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }
    }
}
