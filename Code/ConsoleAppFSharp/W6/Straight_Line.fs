module Straight_Line
open System;
open System.Text.RegularExpressions;

type Line = { Steigung: float; Y_Achse:float }

let createLine a b = 
    {Steigung = a; Y_Achse = b}

let PrintLineFx (line: Line) = 
    printfn "f(x) = %fx + %f" line.Steigung line.Y_Achse

let PrintLine (line: Line) = 
    printfn "y = %fx + %f" line.Steigung line.Y_Achse



let FxToY (s: string) = 
    let trimmed = s.Trim()
    if trimmed.StartsWith("f(x)", StringComparison.OrdinalIgnoreCase) then
        "y" + trimmed.Substring(4)
    else
      trimmed

let ReplaceSpaces (s: string) = 
    s.Replace(" ", "")

let AddYAxis (s:string) = 
    let pattern = ".*[+\-][0-9]+$"
    let matchResult = Regex.Match(s, pattern)
    if matchResult.Success then
        s
    else
        s + "+0"

let PrepareFromString (s:string) = 
    ReplaceSpaces s |> FxToY |> AddYAxis

let TryParseLine (s: string) : Option<Line> = 
    let equation = PrepareFromString s
    let pattern = "^y=([+-]?[0-9]+)x([+-][0-9]+)$"
    let matchResult = Regex.Match(equation, pattern)
    if matchResult.Success then
        let a = float matchResult.Groups.[1].Value
        let b = float matchResult.Groups.[2].Value
        Some (createLine a b)
    else
        None

let MirroeXAxis (line: Line) = 
    createLine (-line.Steigung) line.Y_Achse
 
let MirroeYAxis (line: Line) = 
    createLine line.Steigung (-line.Y_Achse)

let MirroeOrigin (line: Line) = 
    createLine (-line.Steigung) (-line.Y_Achse)