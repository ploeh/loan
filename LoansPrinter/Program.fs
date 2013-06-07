open System
open System.IO
open System.Xml.Xsl
open Ploeh.Samples.Loan.Scenarios

let PrintToFile scenario text =
    let fileName = Path.ChangeExtension(scenario, "md")
    let path = Path.GetFullPath(fileName);
    do File.WriteAllText(path, text)

let PrintGraphReport () =
    let xslt = XslCompiledTransform()
    let graphPath = Path.GetFullPath("graph.xml")
    if File.Exists(graphPath) then
        do xslt.Load(Path.GetFullPath("..\\..\\report.xsl"))
        do xslt.Transform(graphPath, Path.GetFullPath("report.md"))

[<EntryPoint>]
let main argv = 
    do PrintToFile "Scenario 1" (SingleApplicantApplyingForReasonablyPricedHouse())
    do PrintToFile "Scenario 2" (TwoApplicantsApplyingForReasonablyPricedHouse())

    do PrintGraphReport ()
    0
