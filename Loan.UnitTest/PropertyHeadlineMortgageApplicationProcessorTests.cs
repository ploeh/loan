using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.Loan;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;
using Xunit;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class PropertyHeadlineMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new PropertyHeadlineMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResult()
        {
            var sut = new PropertyHeadlineMortgageApplicationProcessor();

            var dummyApplication = new MortgageApplication();
            var actual = sut.ProduceOffer(dummyApplication);

            var expected = new[] 
            {
                new Heading2Rendering("Property")
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOther()
        {
            var sut = new PropertyHeadlineMortgageApplicationProcessor();
            var other = new PropertyHeadlineMortgageApplicationProcessor();

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new PropertyHeadlineMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
