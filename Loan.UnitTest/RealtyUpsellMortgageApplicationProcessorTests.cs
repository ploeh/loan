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
    public class RealtyUpsellMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new RealtyUpsellMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResult()
        {
            var sut = new RealtyUpsellMortgageApplicationProcessor();

            var dummyApplication = new MortgageApplication();
            var actual = sut.ProduceOffer(dummyApplication);

            var expected = new IRendering[]
            {
                new Heading1Rendering("Real estate services"),
                new TextRendering("Do you need help selling your current property? Then  lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }
    }
}
