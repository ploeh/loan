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
    public class PropertyMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new PropertyMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Theory]
        [InlineData("Main Street 7", "14873 Anywhere", "Norway", 184820, 285)]
        [InlineData("Side Street 5", "8888 Somewhere", "Norway", 992829, 567)]
        public void ProduceOfferReturnsCorrectResult(
            string street,
            string postalCode,
            string country,
            int price,
            int size)
        {
            var sut = new PropertyMortgageApplicationProcessor();
            var application = new MortgageApplication
            {
                Property = new Property
                {
                    Address = new Address
                    {
                        Street = street,
                        PostalCode = postalCode,
                        Country = country
                    },
                    Price = price,
                    Size = size
                }
            };

            var actual = sut.ProduceOffer(application);

            var expected =
                new PropertyProcessor
                {
                    PriceText = "Estimated sales price"
                }
                .ProduceRenderings(application.Property);
            Assert.Equal(expected, actual);
        }
    }
}
