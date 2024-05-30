namespace MyFSharpLib_01

open System;

/// <summary>
/// Kopiert aus ConsoleAppFSharp/W8/Lists.fs
/// </summary>
module Lists = 
  let rec filter list predicate = 
    match list with
    | [] -> []
    | head :: tail -> 
      if predicate head then
        head :: filter tail predicate
      else
        filter tail predicate

  let rec map list f =
    match list with
    | [] -> []
    | head :: tail -> (f head) :: map tail f

  let standardAbweichung (list: float list) =
    let avg = List.average list
    let diffsToAvg = map list (fun x -> x - avg)
    let squareDiffs = map diffsToAvg (fun x -> x * x)
    let sumOfSquareDiffs = List.sum squareDiffs
    let t = 1.0 / (float list.Length)
  
    let variance = t * sumOfSquareDiffs
    Math.Sqrt(variance)