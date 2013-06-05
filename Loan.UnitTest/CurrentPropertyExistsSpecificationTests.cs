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
    public class CurrentPropertyExistsSpecificationTests
    {
        [Fact]
        public void SutIsMortgageApplicationSpecification()
        {
            var sut = new CurrentPropertyExistsSpecification();
            Assert.IsAssignableFrom<IMortgageApplicationSpecification>(sut);
        }

        [Fact]
        public void IsSatisfiedByReturnsTrueIfCurrentPropertyHasValue()
        {
            var application = new MortgageApplication
            {
                CurrentProperty = new Property()
            };
            var sut = new CurrentPropertyExistsSpecification();

            var actual = sut.IsSatisfiedBy(application);

            Assert.True(actual);
        }

        [Fact]
        public void IsSatisfiedByReturnsFalseIfCurrentPropertyIsNull()
        {
            var application = new MortgageApplication
            {
                CurrentProperty = null
            };
            var sut = new CurrentPropertyExistsSpecification();

            var actual = sut.IsSatisfiedBy(application);

            Assert.False(actual);
        }
    }
}
