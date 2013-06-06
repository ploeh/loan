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
    public class OfferIntroductionMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new OfferIntroductionMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResult()
        {
            var sut = new OfferIntroductionMortgageApplicationProcessor();

            var dummyApplication = new MortgageApplication();
            var actual = sut.ProduceOffer(dummyApplication);

            var expected = new IRendering[]
            {
                new Heading1Rendering("Loan offer"),
                new TextRendering("It gives us great pleasure to extend to you the following loan offer, lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOther()
        {
            var sut = new OfferIntroductionMortgageApplicationProcessor();
            var other = new OfferIntroductionMortgageApplicationProcessor();

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new OfferIntroductionMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
