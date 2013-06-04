module Ploeh.Samples.Loan.Scenarios

open Ploeh.Samples.Loan
open Ploeh.Samples.Loan.DataCollection
open Ploeh.Samples.Loan.Render
open Ploeh.Samples.Loan.TestDoubles

let processor =
    MortgageApplicationProcessor(
        StubLocationProvider(),
        RealTimeProvider())

let renderer = MarkdownRenderer()

let Render application =
    let renderings = processor.ProduceOffer application
    let markdown =
        renderings |>
        Seq.fold (fun mr ring -> ring.Accept(mr) :?> MarkdownRenderer) renderer
    markdown.ToString()

let SingleApplicantApplyingForReasonablyPricedHouse() =
    MortgageApplication(
        PrimaryApplicant = Applicant(
            Contact = Contact(
                Name = "Jane Doe",
                Address = Address(
                    Street = "Main Street 1",
                    PostalCode = "12345 Anywhere",
                    Country = "Norway")
                ),
            YearlyIncome = 500000m,
            Worth = 100000m,
            TaxationAuthority = "Oslo"
            ),
        SelfPayment = 100000m,
        CurrentProperty = Property(
            Address = Address(
                Street = "Main Street 1",
                PostalCode = "12345 Anywhere",
                Country = "Norway"
            ),
            PropertyType = PropertyType.House,
            Price = 2500000m,
            Size = 160
        ),
        CurrentPropertyWillBeSoldToFinanceNewProperty = true
        ) |>
    Render

let TwoApplicantsApplyingForReasonablyPricedHouse() =
    let application =
        MortgageApplication(
            PrimaryApplicant = Applicant(
                Contact = Contact(
                    Name = "Jane Doe",
                    Address = Address(
                        Street = "Main Street 1",
                        PostalCode = "12345 Anywhere",
                        Country = "Norway")
                    ),
                YearlyIncome = 500000m,
                Worth = 100000m,
                TaxationAuthority = "Oslo"
                ),
            SelfPayment = 250000m
            )
    application.AdditionalApplicants.Add(
        Applicant(
            Contact = Contact(
                Name = "John Doe",
                Address = Address(
                    Street = "Main Street 1",
                    PostalCode = "12345 Anywhere",
                    Country = "Norway")
                ),
                YearlyIncome = 400000m,
                Worth = 250000m,
                TaxationAuthority = "Oslo"
            )
        )
    application |> Render