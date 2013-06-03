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
                )
            )
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
                    )
                )
            )
    application.AdditionalApplicants.Add(
        Applicant(
            Contact = Contact(
                Name = "John Doe",
                Address = Address(
                    Street = "Main Street 1",
                    PostalCode = "12345 Anywhere",
                    Country = "Norway")
                )
            )
        )
    application |> Render