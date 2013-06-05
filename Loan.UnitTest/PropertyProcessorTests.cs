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
    public class PropertyProcessorTests
    {
        [Theory]
        [InlineData("Main Street 7", "14873 Anywhere", "Norway", 184820, 285, "Estimated sales price")]
        [InlineData("Side Street 5", "8888 Somewhere", "Norway", 992829, 567, "Asking price")]
        public void ProduceRenderingsReturnsCorrectResult(
            string street,
            string postalCode,
            string country,
            int price,
            int size,
            string priceText)
        {
            var sut = new PropertyProcessor
            {
                PriceText = priceText
            };
            var property = new Property
            {
                Address = new Address
                {
                    Street = street,
                    PostalCode = postalCode,
                    Country = country
                },
                Price = price,
                Size = size
            };

            IEnumerable<IRendering> actual = sut.ProduceRenderings(property);

            var expected = new IRendering[]
            {
                new BoldRendering("Address:"),
                new TextRendering(
                    " " +
                    street + ", " +
                    postalCode + ", " +
                    country + ". "),
                new LineBreakRendering(),
                new BoldRendering(priceText + ":"),
                new TextRendering(" " + price),
                new LineBreakRendering(),
                new BoldRendering("Size:"),
                new TextRendering(" " + size + " square meters"),
                new LineBreakRendering()
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Asking price", "Asking price", true)]
        [InlineData("Asking price", "Estimated sales price", false)]
        public void SutEqualsOtherReturnsCorrectResult(
            string priceTextSut,
            string priceTextOther,
            bool expected)
        {
            var sut = new PropertyProcessor { PriceText = priceTextSut };
            var other = new PropertyProcessor { PriceText = priceTextOther };

            var actual = sut.Equals(other);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SutDoesNotEqualAnonymousObject()
        {
            var sut = new PropertyProcessor();
            var anonymous = new object();

            var actual = sut.Equals(anonymous);

            Assert.False(actual);
        }
    }
}
