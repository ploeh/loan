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
    public class DesiredLoanTypeMortgageApplicationSpecificationTests
    {
        [Fact]
        public void SutIsMortgageApplicationSpecification()
        {
            var sut = new DesiredLoanTypeMortgageApplicationSpecification();
            Assert.IsAssignableFrom<IMortgageApplicationSpecification>(sut);
        }

        [Theory]
        [InlineData(LoanType.InterestOnly, LoanType.InterestOnly, true)]
        [InlineData(LoanType.FixedRateAnnuity, LoanType.InterestOnly, false)]
        [InlineData(LoanType.FixedRateAnnuity, LoanType.FixedRateAnnuity, true)]
        public void IsSatisfiedByReturnsCorrectResult(
            LoanType matchingLoanType,
            LoanType desiredLoanType,
            bool expected)
        {
            var sut = new DesiredLoanTypeMortgageApplicationSpecification
            {
                MatchingLoanType = matchingLoanType
            };
            var application = new MortgageApplication
            {
                DesiredLoanType = desiredLoanType
            };

            var actual = sut.IsSatisfiedBy(application);

            Assert.Equal(expected, actual);
        }
    }
}
