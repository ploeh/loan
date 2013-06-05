using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class AnyAdditionalApplicantsSpecificationTests
    {
        [Fact]
        public void SutIsMortgageApplicationSpecification()
        {
            var sut = new AnyAdditionalApplicantsSpecification();
            Assert.IsAssignableFrom<IMortgageApplicationSpecification>(sut);
        }

        [Fact]
        public void IsSatisfiedByApplicationWithAdditionalApplicantsReturnsTrue()
        {
            var application = new MortgageApplication();
            application.AdditionalApplicants.Add(new Applicant());
            application.AdditionalApplicants.Add(new Applicant());
            var sut = new AnyAdditionalApplicantsSpecification();

            var actual = sut.IsSatisfiedBy(application);

            Assert.True(actual);
        }

        [Fact]
        public void IsSatisfiedByAplicationWithNoAdditionalApplicantsReturnsFalse()
        {
            var application = new MortgageApplication();
            var sut = new AnyAdditionalApplicantsSpecification();

            var actual = sut.IsSatisfiedBy(application);

            Assert.False(actual);
        }

        [Fact]
        public void SutEqualsOther()
        {
            var sut = new AnyAdditionalApplicantsSpecification();
            var other = new AnyAdditionalApplicantsSpecification();

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new AnyAdditionalApplicantsSpecification();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
