using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Moq;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class MortgageApplicationProcessorComposerTests
    {
        [Fact]
        public void ComposeReturnsCorrectResult()
        {
            var sut = new MortgageApplicationProcessorComposer
            {
                LocationProvider = new Mock<ILocationProvider>().Object,
                TimeProvider = new Mock<ITimeProvider>().Object,
                OfferService = new Mock<IOfferService>().Object
            };

            IMortgageApplicationProcessor actual = sut.Compose();

            var expected = new CompositeMortgageApplicationProcessor
            {
                Nodes = new IMortgageApplicationProcessor[]
                {
                    new DateAndLocationMortgageApplicationProcessor
                    {
                        LocationProvider = sut.LocationProvider,
                        TimeProvider = sut.TimeProvider
                    },
                    new GreetingMortgageApplicationProcessor(),
                    new ApplicationDetailsHeadlineMortgageApplicationProcessor(),
                    new PrimaryApplicantMortgageApplicationProcessor(),
                    new ConditionalMortgageApplicationProcessor
                    {
                        Specification = new AnyAdditionalApplicantsSpecification(),
                        TruthProcessor = new PrimaryApplicantMortgageApplicationProcessor()
                    },
                    new FinancingHeadlineMortgageApplicationProcessor(),
                    new SelfPaymentMortgageApplicationProcessor(),
                    new ConditionalMortgageApplicationProcessor
                    {
                        Specification = new AndMortgageApplicationSpecification
                        {
                            Specifications = new IMortgageApplicationSpecification[]
                            {
                                new CurrentPropertyExistsSpecification(),
                                new CurrentPropertySoldAsFinancingMortgageApplicationSpecification()
                            }
                        },
                        TruthProcessor = new CurrentPropertyMortgageApplicationProcessor()
                    },
                    new PropertyHeadlineMortgageApplicationProcessor(),
                    new PropertyMortgageApplicationProcessor(),
                    new DesiredLoanMortgageApplicationProcessor(),
                    new OfferIntroductionMortgageApplicationProcessor(),
                    new ConditionalMortgageApplicationProcessor
                    {
                        Specification = new DesiredLoanTypeMortgageApplicationSpecification
                        {
                            MatchingLoanType = LoanType.FixedRateAnnuity
                        },
                        TruthProcessor = new FixedRateAnnuityOfferMortgageApplicationProcessor
                        {
                            OfferService = sut.OfferService
                        }
                    },
                    new ConditionalMortgageApplicationProcessor
                    {
                        Specification = new DesiredLoanTypeMortgageApplicationSpecification
                        {
                            MatchingLoanType = LoanType.AdjustableRateAnnuity
                        },
                        TruthProcessor = new AdjustableRateAnnuityOfferMortgageApplicationProcessor
                        {
                            OfferService = sut.OfferService
                        }
                    },
                    new ConditionalMortgageApplicationProcessor
                    {
                        Specification = new DesiredLoanTypeMortgageApplicationSpecification
                        {
                            MatchingLoanType = LoanType.InterestOnly
                        },
                        TruthProcessor = new InterestOnlyOfferMortgageApplicationProcessor
                        {
                            OfferService = sut.OfferService
                        }
                    }
                }
            };
            Assert.Equal(expected, actual);
        }
    }
}
