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
    public class GreetingMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new GreetingMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData("Jane Doe", "Main Street 1", "12345 Anywhere", "Norway")]
        [InlineData("John Doe", "Side Street 8", "54321 Somewhere", "USA")]
        public void ProduceOfferReturnsCorrectResult(
            string name,
            string street,
            string postalCode,
            string country)
        {
            var sut = new GreetingMortgageApplicationProcessor();
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
                    }
                }
            };

            var actual = sut.ProduceOffer(application);

            var expected = new IRendering[]
            {
                new TextRendering(
                    "Dear " +
                    name + ", " +
                    street + ", " +
                    postalCode + ", " +
                    country),
                new LineBreakRendering(),
                new TextRendering("It gives us great pleasure to lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }
    }
}
