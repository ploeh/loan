open System
open System.IO
open Ploeh.Samples.Loan.Scenarios

let PrintToFile scenario text =
    let fileName = Path.ChangeExtension(scenario, "md")
    let path = Path.GetFullPath(fileName);
    do File.WriteAllText(path, text)

[<EntryPoint>]
let main argv = 
    do PrintToFile "Scenario 1" (SingleApplicantApplyingForReasonablyPricedHouse())
    0
