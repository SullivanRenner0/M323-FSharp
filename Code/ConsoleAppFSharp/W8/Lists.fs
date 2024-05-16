module ListsW8
open System;

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

let rec absList list = 
  match list with
  | [] -> []
  | head :: tail -> (abs head) :: absList tail

let rec getMax (list: int list) = 
  let rec loop (list:int list) (max:int) = 
    match list with
    | [] -> max
    | head :: tail -> 
      if head > max then
        loop tail head
      else
        loop tail max
  loop list Int32.MinValue

let getPercent (value: float) (max: float) : float = 
  (value / max) * 100.0

let getpercentageOfMax list = 
  let absList = absList list
  let max = getMax absList
  map absList (fun x -> getPercent (float x) (float max))

let filterRangePercentage list min max = 
  let absList = absList list
  let max = getMax absList
  filter absList (fun x ->
    let p = getPercent (float x) (float max)
    p >= min && p <= max
    )

let rec sumOfSquare list = 
  map list (fun x -> x * x) |> List.sum


type Artikel = { Name: string; Preis: float; }
let getGesamtPreis (artikels: Artikel list) = 
  let preise = map artikels (fun x -> x.Preis)
  List.sum preise

let joinStrings (separator: string) (list: string list)  = 
  map list (fun x -> x.Trim()) 
  |> List.filter (fun x -> x.Length > 0)
  |> List.fold (fun all x -> if all = "" then x else all + separator + x) ""

let joinStringsUnderscore = 
  joinStrings "_"


let sortAtrikel (list: (int*string*int) list) : (int*string*int) list = 
  List.sortBy (fun (preis, _, _) -> preis) list

let standardAbweichung (list: float list) =
  let avg = List.average list
  let diffsToAvg = map list (fun x -> x - avg)
  let squareDiffs = map diffsToAvg (fun x -> x * x)
  let sumOfSquareDiffs = List.sum squareDiffs
  let t = 1.0 / (float list.Length)

  let variance = t * sumOfSquareDiffs
  Math.Sqrt(variance)

  

