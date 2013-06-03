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