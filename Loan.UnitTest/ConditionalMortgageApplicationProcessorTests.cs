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
    public class ConditionalMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new ConditionalMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResultWhenSpecificationIsSatisfied()
        {
            // Arrange
            var application = new MortgageApplication();

            var sut = new ConditionalMortgageApplicationProcessor
            {
                Specification = new Mock<IMortgageApplicationSpecification>().Object,
                TruthProcessor = new Mock<IMortgageApplicationProcessor>().Object
            };

            Mock.Get(sut.Specification)
                .Setup(s => s.IsSatisfiedBy(application))
                .Returns(true);

            var expected = new []
            {
                new Mock<IRendering>().Object,
                new Mock<IRendering>().Object,
                new Mock<IRendering>().Object,
            };

            Mock.Get(sut.TruthProcessor)
                .Setup(p => p.ProduceOffer(application))
                .Returns(expected);

            // Act
            var actual = sut.ProduceOffer(application);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProduceOfferReturnsCorrectResultWhenSpecificationIsNotSatisfied()
        {
            // Arrange
            var application = new MortgageApplication();

            var sut = new ConditionalMortgageApplicationProcessor
            {
                Specification = new Mock<IMortgageApplicationSpecification>().Object,
                TruthProcessor = new Mock<IMortgageApplicationProcessor>().Object
            };

            Mock.Get(sut.Specification)
                .Setup(s => s.IsSatisfiedBy(application))
                .Returns(false);
            Mock.Get(sut.TruthProcessor)
                .Setup(s => s.ProduceOffer(It.IsAny<MortgageApplication>()))
                .Returns(new[] { new Mock<IRendering>().Object });

            // Act
            var actual = sut.ProduceOffer(application);

            // Assert
            Assert.Empty(actual);
        }
    }
}
