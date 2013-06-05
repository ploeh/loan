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
    public class CurrentPropertyMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new CurrentPropertyMortgageApplicationProcessor();
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
            var sut = new CurrentPropertyMortgageApplicationProcessor();
            var application = new MortgageApplication
            {
                CurrentProperty = new Property
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

            var expected = new IRendering[]
            {
                new TextRendering("Current property will be sold to finance new property."),
                new LineBreakRendering(),
            }
            .Concat(new PropertyProcessor().ProduceRenderings(application.CurrentProperty));
            Assert.Equal(expected, actual);
        }
    }
}
