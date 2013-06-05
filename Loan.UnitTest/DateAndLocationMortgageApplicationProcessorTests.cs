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

        [Fact]
        public void SutEqualsOtherWithSameProviders()
        {
            var moqRepo = new MockRepository(MockBehavior.Default);
            var sut = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = moqRepo.Create<ILocationProvider>().Object,
                TimeProvider = moqRepo.Create<ITimeProvider>().Object
            };
            var other = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = sut.LocationProvider,
                TimeProvider = sut.TimeProvider
            };

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new DateAndLocationMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }

        [Fact]
        public void SutDoesNotEqualOtherWithDifferentLocationProvider()
        {
            var moqRepo = new MockRepository(MockBehavior.Default);
            var sut = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = moqRepo.Create<ILocationProvider>().Object,
                TimeProvider = moqRepo.Create<ITimeProvider>().Object
            };
            var other = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = moqRepo.Create<ILocationProvider>().Object,
                TimeProvider = sut.TimeProvider
            };

            var actual = sut.Equals(other);

            Assert.False(actual);
        }

        [Fact]
        public void SutDoesNotEqualOtherWithDifferentTimeProvider()
        {
            var moqRepo = new MockRepository(MockBehavior.Default);
            var sut = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = moqRepo.Create<ILocationProvider>().Object,
                TimeProvider = moqRepo.Create<ITimeProvider>().Object
            };
            var other = new DateAndLocationMortgageApplicationProcessor
            {
                LocationProvider = sut.LocationProvider,
                TimeProvider = moqRepo.Create<ITimeProvider>().Object
            };

            var actual = sut.Equals(other);

            Assert.False(actual);
        }
    }
}
