using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.Samples.Loan.DataCollection;

namespace Ploeh.Samples.Loan
{
    public class MortgageApplicationProcessorComposer
    {
        public ILocationProvider LocationProvider;
        public ITimeProvider TimeProvider;
        public IOfferService OfferService;

        public IMortgageApplicationProcessor Compose()
        {
            return new CompositeMortgageApplicationProcessor
            {
                Nodes = new IMortgageApplicationProcessor[]
                {
                    new DateAndLocationMortgageApplicationProcessor
                    {
                        LocationProvider = this.LocationProvider,
                        TimeProvider = this.TimeProvider
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
                            OfferService = this.OfferService
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
                            OfferService = this.OfferService
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
                            OfferService = this.OfferService
                        }
                    }
                }
            };
        }
    }
}
