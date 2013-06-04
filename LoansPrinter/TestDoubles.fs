module Ploeh.Samples.Loan.TestDoubles

open System
open Ploeh.Samples.Loan

type StubLocationProvider() =
    interface ILocationProvider with
        member this.GetCurrentLocationName() =
            "Oslo"

type RealTimeProvider() =
    interface ITimeProvider with
        member this.GetCurrentTime() =
            DateTimeOffset.Now

type FakeOfferService() =
    interface IOfferService with
        member this.GetFixedRateAnnuityOffer(application) =
            FixedRateAnnuityOffer(
                Rate = 35,
                Term = DateTimeOffset.Now.AddYears(application.DesiredTerm)
            )
        member this.GetAdjustableRateAnnuityOffer(application) =
            AdjustableRateAnnuityOffer(
                InitialRate = 21,
                Term = DateTimeOffset.Now.AddYears(application.DesiredTerm)
            )
        member this.GetInterestOnlyOffer(application) =
            InterestOnlyOffer(
                Rate = 55,
                Term = DateTimeOffset.Now.AddYears(1)
            )