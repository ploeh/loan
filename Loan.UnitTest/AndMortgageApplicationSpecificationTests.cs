using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Moq;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class AndMortgageApplicationSpecificationTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new AndMortgageApplicationSpecification();
            Assert.IsAssignableFrom<IMortgageApplicationSpecification>(sut);
        }

        [Theory]
        [InlineData(true , true , true , true )]
        [InlineData(false, true , true , false)]
        [InlineData(true , false, true , false)]
        [InlineData(true , true , false, false)]
        [InlineData(true , true , false, false)]
        [InlineData(false, false, false, false)]
        public void IsSatisfiedByReturnsCorrectResult(
            bool b1,
            bool b2,
            bool b3,
            bool expected)
        {
            // Arrange
            var application = new MortgageApplication();

            var spec1 = new Mock<IMortgageApplicationSpecification>();
            var spec2 = new Mock<IMortgageApplicationSpecification>();            
            var spec3 = new Mock<IMortgageApplicationSpecification>();
            spec1.Setup(s => s.IsSatisfiedBy(application)).Returns(b1);
            spec2.Setup(s => s.IsSatisfiedBy(application)).Returns(b2);
            spec3.Setup(s => s.IsSatisfiedBy(application)).Returns(b3);

            var sut = new AndMortgageApplicationSpecification();
            sut.Specifications.Add(spec1.Object);
            sut.Specifications.Add(spec2.Object);
            sut.Specifications.Add(spec3.Object);

            // Act
            var actual = sut.IsSatisfiedBy(application);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOtherWithSameSpecifications()
        {
            // Arrange
            var spec1 = new Mock<IMortgageApplicationSpecification>();
            var spec2 = new Mock<IMortgageApplicationSpecification>();
            var spec3 = new Mock<IMortgageApplicationSpecification>();

            var sut = new AndMortgageApplicationSpecification();
            sut.Specifications.Add(spec1.Object);
            sut.Specifications.Add(spec2.Object);
            sut.Specifications.Add(spec3.Object);

            var other = new AndMortgageApplicationSpecification();
            other.Specifications.Add(spec1.Object);
            other.Specifications.Add(spec2.Object);
            other.Specifications.Add(spec3.Object);

            // Act
            var actual = sut.Equals(other);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new AndMortgageApplicationSpecification();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }

        [Fact]
        public void SutDoesNotEqualOtherWithDifferentSpecifications()
        {
            // Arrange
            var sut = new AndMortgageApplicationSpecification();
            sut.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);
            sut.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);
            sut.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);

            var other = new AndMortgageApplicationSpecification();
            other.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);
            other.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);
            other.Specifications.Add(new Mock<IMortgageApplicationSpecification>().Object);

            // Act
            var actual = sut.Equals(other);

            // Assert
            Assert.False(actual);
        }
    }
}
