using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Moq;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class FixedRateAnnuityOfferMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new FixedRateAnnuityOfferMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData(34, "2043-06-06")]
        [InlineData(45, "2033-01-01")]
        public void ProduceOfferReturnsCorrectResult(
            int rate,
            string term)
        {
            var application = new MortgageApplication();
            var offer = new FixedRateAnnuityOffer
            {
                Rate = rate,
                Term = DateTimeOffset.Parse(term)
            };
            var sut = new FixedRateAnnuityOfferMortgageApplicationProcessor
            {
                OfferService = new Mock<IOfferService>().Object
            };
            Mock.Get(sut.OfferService)
                .Setup(o => o.GetFixedRateAnnuityOffer(application))
                .Returns(offer);

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new Heading2Rendering("Fixed rate offer"),
                new BoldRendering("Interest rate:"),
                new TextRendering(" " + offer.Rate / 10m + " %"),
                new LineBreakRendering(),
                new BoldRendering("Term:"),
                new TextRendering(" " + offer.Term.ToString("D")),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOtherWithSameDependencies()
        {
            var sut = new FixedRateAnnuityOfferMortgageApplicationProcessor
            {
                OfferService = new Mock<IOfferService>().Object
            };
            var other = new FixedRateAnnuityOfferMortgageApplicationProcessor
            {
                OfferService = sut.OfferService
            };

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new FixedRateAnnuityOfferMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }

        [Fact]
        public void SutDoesNotEqualOtherWithDifferentDependencies()
        {
            var sut = new FixedRateAnnuityOfferMortgageApplicationProcessor
            {
                OfferService = new Mock<IOfferService>().Object
            };
            var other = new FixedRateAnnuityOfferMortgageApplicationProcessor
            {
                OfferService = new Mock<IOfferService>().Object
            };

            var actual = sut.Equals(other);

            Assert.False(actual);
        }
    }
}
