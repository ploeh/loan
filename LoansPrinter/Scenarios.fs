module Ploeh.Samples.Loan.Scenarios

open System.IO
open System.Runtime.Serialization
open System.Xml
open Ploeh.Samples.Loan
open Ploeh.Samples.Loan.DataCollection
open Ploeh.Samples.Loan.Render
open Ploeh.Samples.Loan.TestDoubles

let processor =
    let serializer = 
        DataContractSerializer(
            typeof<CompositeMortgageApplicationProcessor>,
            [
                typeof<StubLocationProvider>;
                typeof<RealTimeProvider>;
                typeof<FakeOfferService>;                
            ] |> 
            Seq.append (typeof<IMortgageApplicationProcessor>.Assembly.GetExportedTypes() |>
            Seq.filter (fun t -> t.IsDefined(typeof<DataContractAttribute>, false)) ))
    
    let graphPath = Path.GetFullPath("graph.xml")
    if File.Exists(graphPath)
    then
        use xr = XmlReader.Create(graphPath)
        serializer.ReadObject(xr) :?> IMortgageApplicationProcessor
    else
        let composer =
            MortgageApplicationProcessorComposer(
                LocationProvider = StubLocationProvider(),
                TimeProvider = RealTimeProvider(),
                OfferService = FakeOfferService())
        let g = composer.Compose()

        use xw = XmlWriter.Create(graphPath, XmlWriterSettings(Indent = true))
        serializer.WriteObject(xw, g)

        g

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
        CurrentPropertyWillBeSoldToFinanceNewProperty = true,
        Property = Property(
            Address = Address(
                Street = "Side Street 10",
                PostalCode = "67890 Somewhere",
                Country = "Norway"
            ),
            PropertyType = PropertyType.House,
            Price = 3500000m,
            Size = 190
        ),
        DesiredLoanType = LoanType.AdjustableRateAnnuity,
        DesiredTerm = 30,
        DesiredFrequency = PaymentFrequency.Quarterly
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
            SelfPayment = 250000m,
            Property = Property(
                Address = Address(
                    Street = "Side Street 10",
                    PostalCode = "67890 Somewhere",
                    Country = "Norway"
                ),
                PropertyType = PropertyType.House,
                Price = 3500000m,
                Size = 190
            ),
            DesiredLoanType = LoanType.FixedRateAnnuity,
            DesiredTerm = 20,
            DesiredFrequency = PaymentFrequency.Quarterly
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