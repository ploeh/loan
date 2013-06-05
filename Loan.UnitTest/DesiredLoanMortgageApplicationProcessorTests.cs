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
    public class DesiredLoanMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new DesiredLoanMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData(LoanType.FixedRateAnnuity, 1, PaymentFrequency.Monthly)]
        [InlineData(LoanType.InterestOnly, 4, PaymentFrequency.Yearly)]
        public void ProduceOfferReturnsCorrectResult(
            LoanType loanType,
            int term,
            PaymentFrequency frequency)
        {
            var sut = new DesiredLoanMortgageApplicationProcessor();
            var application = new MortgageApplication
            {
                DesiredLoanType = loanType,
                DesiredTerm = term,
                DesiredFrequency = frequency
            };

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new Heading2Rendering("Desired loan"),
                new BoldRendering("Loan type:"),
                new TextRendering(" " + loanType),
                new LineBreakRendering(),
                new BoldRendering("Term:"),
                new TextRendering(" " + term + " years."),
                new LineBreakRendering(),
                new BoldRendering("Frequency:"),
                new TextRendering(" " + frequency),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOther()
        {
            var sut = new DesiredLoanMortgageApplicationProcessor();
            var other = new DesiredLoanMortgageApplicationProcessor();

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new DesiredLoanMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
