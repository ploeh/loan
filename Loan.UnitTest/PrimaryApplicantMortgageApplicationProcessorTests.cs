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
    public class PrimaryApplicantMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new PrimaryApplicantMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData("Jane Doe", "Main Street 1", "12345 Anywhere", "Norway", 400000, "Oslo")]
        [InlineData("John Doe", "Side Street 9", "4328 Somewhere", "Denmark", 400000, "Copenhagen")]
        public void ProduceOfferReturnsCorrectResult(
            string name,
            string street,
            string postalCode,
            string country,
            int yearlyIncome,
            string taxAuthority)
        {
            var sut = new PrimaryApplicantMortgageApplicationProcessor();
            var application = new MortgageApplication
            {
                PrimaryApplicant = new Applicant
                {
                    Contact = new Contact
                    {
                        Name = name,
                        Address = new Address
                        {
                            Street = street,
                            PostalCode = postalCode,
                            Country = country
                        }
                    },
                    YearlyIncome = yearlyIncome,
                    TaxationAuthority = taxAuthority
                }
            };

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new BoldRendering("Primary applicant:")
            }
            .Concat(new ApplicantProcessor().ProduceRenderings(
                application.PrimaryApplicant));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutEqualsOther()
        {
            var sut = new PrimaryApplicantMortgageApplicationProcessor();
            var other = new PrimaryApplicantMortgageApplicationProcessor();

            var actual = sut.Equals(other);

            Assert.True(actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new PrimaryApplicantMortgageApplicationProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
