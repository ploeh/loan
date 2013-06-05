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
    public class DateAndLocationMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new DateAndLocationMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData("Copenhagen", "2013-06-05")]
        [InlineData("Oslo", "2013-06-10")]
        public void ProduceOfferReturnsCorrectResult(
            string locationName,
            string currentTime)
        {
            // Arrange
            var moqRepo = new MockRepository(MockBehavior.Default);

            var sut = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = moqRepo.Create<ILocationProvider>().Object,
                TimeProvider = moqRepo.Create<ITimeProvider>().Object
            };

            Mock.Get(sut.LocationProvider)
                .Setup(lp => lp.GetCurrentLocationName())
                .Returns(locationName);
            Mock.Get(sut.TimeProvider)
                .Setup(tp => tp.GetCurrentTime())
                .Returns(DateTimeOffset.Parse(currentTime));

            // Act
            var dummyApplication = new MortgageApplication();
            var actual = sut.ProduceOffer(dummyApplication);

            // Assert
            var expected = new IRendering[]
            {
                new TextRendering(
                    locationName +
                    ", " +
                    DateTimeOffset.Parse(currentTime).ToString("D")),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }
    }
}
