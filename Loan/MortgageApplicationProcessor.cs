﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.Samples.Loan.DataCollection;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan
{
    public class MortgageApplicationProcessor : IMortgageApplicationProcessor
    {
        private readonly ILocationProvider locationProvider;
        private readonly ITimeProvider timeProvider;
        private readonly IOfferService offerService;

        public MortgageApplicationProcessor(
            ILocationProvider locationProvider,
            ITimeProvider timeProvider,
            IOfferService offerService)
        {
            this.locationProvider = locationProvider;
            this.timeProvider = timeProvider;
            this.offerService = offerService;
        }

        public IEnumerable<IRendering> ProduceOffer(MortgageApplication application)
        {
            var renderings = new List<IRendering>();

            // Date and location
            renderings.Add(
                new TextRendering(
                    this.locationProvider.GetCurrentLocationName() +
                    ", " +
                    this.timeProvider.GetCurrentTime().ToString("D")));
            renderings.Add(new LineBreakRendering());

            // Greeting
            renderings.Add(
                new TextRendering(
                    "Dear " +
                    application.PrimaryApplicant.Contact.Name + ", " +
                    application.PrimaryApplicant.Contact.Address.Street + ", " +
                    application.PrimaryApplicant.Contact.Address.PostalCode + ", " +
                    application.PrimaryApplicant.Contact.Address.Country));
            renderings.Add(new LineBreakRendering());

            renderings.Add(
                new TextRendering(
                    "It gives us great pleasure to lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));
            renderings.Add(new LineBreakRendering());

            // Application details
            renderings.Add(new Heading1Rendering("Application details"));

            // Primary applicant
            renderings.Add(new BoldRendering("Primary applicant:"));
            renderings.Add(
                new TextRendering(
                    " " +
                    application.PrimaryApplicant.Contact.Name + ", " +
                    application.PrimaryApplicant.Contact.Address.Street + ", " +
                    application.PrimaryApplicant.Contact.Address.PostalCode + ", " +
                    application.PrimaryApplicant.Contact.Address.Country + ". "));
            renderings.Add(new BoldRendering("Yearly income:"));
            renderings.Add(
                new TextRendering(
                    " " + application.PrimaryApplicant.YearlyIncome + ". "));
            renderings.Add(new BoldRendering("Worth:"));
            renderings.Add(
                new TextRendering(
                    " " + application.PrimaryApplicant.Worth + ". "));
            renderings.Add(new BoldRendering("Tax authority:"));
            renderings.Add(
                new TextRendering(
                    " " + application.PrimaryApplicant.TaxationAuthority + "."));
            renderings.Add(new LineBreakRendering());

            // Additional applicants
            if (application.AdditionalApplicants.Any())
            {
                renderings.Add(new BoldRendering("Additional applicants:"));
                renderings.Add(new LineBreakRendering());

                foreach (var applicant in application.AdditionalApplicants)
                {
                    renderings.Add(
                        new BulletRendering(
                            applicant.Contact.Name + ", " +
                            applicant.Contact.Address.Street + ", " +
                            applicant.Contact.Address.PostalCode + ", " +
                            applicant.Contact.Address.Country + ". "));
                    renderings.Add(new BoldRendering("Yearly income:"));
                    renderings.Add(
                        new TextRendering(
                            " " + applicant.YearlyIncome + ". "));
                    renderings.Add(new BoldRendering("Worth:"));
                    renderings.Add(
                        new TextRendering(
                            " " + applicant.Worth + ". "));
                    renderings.Add(new BoldRendering("Tax authority:"));
                    renderings.Add(
                        new TextRendering(
                            " " + applicant.TaxationAuthority + "."));
                    renderings.Add(new LineBreakRendering());
                }
            }

            // Financing sub-section
            renderings.Add(new Heading2Rendering("Financing"));

            // Self payment
            renderings.Add(new BoldRendering("Self payment:"));
            renderings.Add(new TextRendering(" " + application.SelfPayment));
            renderings.Add(new LineBreakRendering());

            // Current property
            if (application.CurrentProperty != null &&
                application.CurrentPropertyWillBeSoldToFinanceNewProperty)
            {
                renderings.Add(new TextRendering("Current property will be sold to finance new property."));
                renderings.Add(new LineBreakRendering());

                renderings.Add(new BoldRendering("Address:"));
                renderings.Add(
                    new TextRendering(
                        " " +
                        application.CurrentProperty.Address.Street + ", " +
                        application.CurrentProperty.Address.PostalCode + ", " +
                        application.CurrentProperty.Address.Country + ". "));
                renderings.Add(new LineBreakRendering());

                renderings.Add(new BoldRendering("Estimated sales price:"));
                renderings.Add(
                    new TextRendering(
                        " " + application.CurrentProperty.Price));
                renderings.Add(new LineBreakRendering());

                renderings.Add(new BoldRendering("Size:"));
                renderings.Add(
                    new TextRendering(
                        " " + application.CurrentProperty.Size + " square meters"));
                renderings.Add(new LineBreakRendering());
            }

            // Property sub-section
            renderings.Add(new Heading2Rendering("Property"));

            renderings.Add(new BoldRendering("Address:"));
            renderings.Add(
                new TextRendering(
                    " " +
                    application.Property.Address.Street + ", " +
                    application.Property.Address.PostalCode + ", " +
                    application.Property.Address.Country + ". "));
            renderings.Add(new LineBreakRendering());

            renderings.Add(new BoldRendering("Asking price:"));
            renderings.Add(
                new TextRendering(
                    " " + application.Property.Price));
            renderings.Add(new LineBreakRendering());

            renderings.Add(new BoldRendering("Size:"));
            renderings.Add(
                new TextRendering(
                    " " + application.Property.Size + " square meters"));
            renderings.Add(new LineBreakRendering());

            // Desired loan characteristics
            renderings.Add(new Heading2Rendering("Desired loan"));

            renderings.Add(new BoldRendering("Loan type:"));
            renderings.Add(
                new TextRendering(
                    " " + application.DesiredLoanType));
            renderings.Add(new LineBreakRendering());

            renderings.Add(new BoldRendering("Term:"));
            renderings.Add(
                new TextRendering(
                    " " + application.DesiredTerm + " years."));
            renderings.Add(new LineBreakRendering());

            renderings.Add(new BoldRendering("Frequency:"));
            renderings.Add(
                new TextRendering(
                    " " + application.DesiredFrequency));
            renderings.Add(new LineBreakRendering());

            /*
             * Offer section
             * */

            renderings.Add(new Heading1Rendering("Loan offer"));
            renderings.Add(new TextRendering("It gives us great pleasure to extend to you the following loan offer, lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));
            renderings.Add(new LineBreakRendering());

            switch (application.DesiredLoanType)
            {
                case LoanType.FixedRateAnnuity:
                    var fixedRateOffer = 
                        this.offerService.GetFixedRateAnnuityOffer(application);
                    
                    renderings.Add(new Heading2Rendering("Fixed rate offer"));

                    renderings.Add(new BoldRendering("Interest rate:"));
                    renderings.Add(
                        new TextRendering(
                            " " + fixedRateOffer.Rate / 10m + " %"));
                    renderings.Add(new LineBreakRendering());

                    renderings.Add(new BoldRendering("Term:"));
                    renderings.Add(
                        new TextRendering(
                            " " + fixedRateOffer.Term.ToString("D")));
                    renderings.Add(new LineBreakRendering());

                    break;
                case LoanType.AdjustableRateAnnuity:
                    var adjustableRateOffer =
                        this.offerService.GetAdjustableRateAnnuityOffer(application);

                    renderings.Add(new Heading2Rendering("Adjustable rate offer"));

                    renderings.Add(new BoldRendering("Initial interest rate:"));
                    renderings.Add(
                        new TextRendering(
                            " " + adjustableRateOffer.InitialRate / 10m + " %"));
                    renderings.Add(new LineBreakRendering());

                    renderings.Add(new BoldRendering("Term:"));
                    renderings.Add(
                        new TextRendering(
                            " " + adjustableRateOffer.Term.ToString("D")));
                    renderings.Add(new LineBreakRendering());

                    break;
                case LoanType.InterestOnly:
                    var interestOnlyOffer =
                        this.offerService.GetInterestOnlyOffer(application);

                    renderings.Add(new Heading2Rendering("Interest only offer"));

                    renderings.Add(new BoldRendering("Interest rate:"));
                    renderings.Add(
                        new TextRendering(
                            " " + interestOnlyOffer.Rate / 10m + " %"));
                    renderings.Add(new LineBreakRendering());

                    renderings.Add(new BoldRendering("Term:"));
                    renderings.Add(
                        new TextRendering(
                            " " + interestOnlyOffer.Term.ToString("D")));
                    renderings.Add(new LineBreakRendering());

                    break;
                default:
                    break;
            }

            return renderings;
        }
    }
}
