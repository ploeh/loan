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
    public class AdditionalApplicantsMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new AdditionalApplicantsMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData("Jane Doe", "Main Street 1", "12345 Anywhere", "Norway", 400000, "Oslo")]
        [InlineData("John Doe", "Side Street 9", "4328 Somewhere", "Denmark", 400000, "Copenhagen")]
        public void ProduceOfferReturnsCorrectResultWithOneAdditionalApplicant(
            string name,
            string street,
            string postalCode,
            string country,
            int yearlyIncome,
            string taxAuthority)
        {
            var applicant = new Applicant
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
            };
            var application = new MortgageApplication();
            application.AdditionalApplicants.Add(applicant);
            var sut = new AdditionalApplicantsMortgageApplicationProcessor();

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new BoldRendering("Additional applicants:"),
                new LineBreakRendering(),
                new BulletRendering("")
            }
            .Concat(new ApplicantProcessor().ProduceRenderings(applicant));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Jane Doe", "Main Street 1", "12345 Anywhere", "Norway", 400000, "Oslo", "Mary Roe", "Main Street 2", "11345 Anywhere", "Belgium", 200000, "Bruxelles")]
        [InlineData("John Doe", "Side Street 9", "4328 Somewhere", "Denmark", 400000, "Copenhagen", "Kloge Åge", "Side Street 2", "4322 Somewhere", "Sweden", 800000, "Stockholm")]
        public void ProduceOfferReturnsCorrectResultWithTwoAdditionalApplicant(
            string name1,
            string street1,
            string postalCode1,
            string country1,
            int yearlyIncome1,
            string taxAuthority1,
            string name2,
            string street2,
            string postalCode2,
            string country2,
            int yearlyIncome2,
            string taxAuthority2)
        {
            var applicant1 = new Applicant
            {
                Contact = new Contact
                {
                    Name = name1,
                    Address = new Address
                    {
                        Street = street1,
                        PostalCode = postalCode1,
                        Country = country1
                    }
                },
                YearlyIncome = yearlyIncome1,
                TaxationAuthority = taxAuthority1
            };
            var applicant2 = new Applicant
            {
                Contact = new Contact
                {
                    Name = name2,
                    Address = new Address
                    {
                        Street = street2,
                        PostalCode = postalCode2,
                        Country = country2
                    }
                },
                YearlyIncome = yearlyIncome2,
                TaxationAuthority = taxAuthority2
            };
            var application = new MortgageApplication();
            application.AdditionalApplicants.Add(applicant1);
            application.AdditionalApplicants.Add(applicant2);
            var sut = new AdditionalApplicantsMortgageApplicationProcessor();

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new BoldRendering("Additional applicants:"),
                new LineBreakRendering(),
                new BulletRendering("")
            }
            .Concat(new ApplicantProcessor().ProduceRenderings(applicant1))
            .Concat(new IRendering[] { new BulletRendering("") })
            .Concat(new ApplicantProcessor().ProduceRenderings(applicant2));
            Assert.Equal(expected, actual);
        }
    }
}
