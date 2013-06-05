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
    public class ApplicantProcessorTests
    {
        [Theory]
        [InlineData("Jane Doe", "Main Street 1", "12345 Anywhere", "Norway", 400000, "Oslo")]
        [InlineData("John Doe", "Side Street 9", "4328 Somewhere", "Denmark", 400000, "Copenhagen")]
        public void ProduceRenderingsReturnsCorrectResult(
            string name,
            string street,
            string postalCode,
            string country,
            int yearlyIncome,
            string taxAuthority)
        {
            var sut = new ApplicantProcessor();
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

            IEnumerable<IRendering> actual = sut.ProduceRenderings(applicant);

            var expected = new IRendering[]
            {
                new TextRendering(
                    " " +
                    name + ", " +
                    street + ", " +
                    postalCode + ", " +
                    country + ". "),
                new BoldRendering("Yearly income:"),
                new TextRendering(" " + yearlyIncome + ". "),
                new BoldRendering("Tax authority:"),
                new TextRendering(" " + taxAuthority + "."),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }
    }
}
