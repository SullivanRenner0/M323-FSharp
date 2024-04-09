module Lists

let rec filter list predicate = 
  match list with
  | [] -> []
  | head :: tail -> 
    if predicate head then
      head :: filter tail predicate
    else
      filter tail predicate
      
let filterEven list =
  filter list (fun x -> x % 2 = 0)
      
let filterOdd list =
  filter list (fun x -> x % 2 <> 0)

let rec sum list =
  match list with
  | [] -> 0
  | head :: tail -> head + sum tail
  
let rec squareAll list = 
  match list with
  | [] -> []
  | head :: tail -> head * head :: squareAll tail


let filterGreaterThan list n = 
  filter list (fun x -> x > n) |> sum

let filterBetween list min max = 
  filter list (fun x -> x > min && x < max) |> sum

let rec sumEven list = 
  filterEven(list) |> sum

let rec sumSquareOfOdd list = 
  filterOdd(list) |> squareAll |> sum


let rec bubblesort (list) = 
  let rec swap list = 
    match list with
    | [] | [_] -> list
    | first :: second :: tail -> 
      if first < second then
        first :: swap (second :: tail)
      else
        second :: swap (first :: tail)

  let rec loop list = 
    let swappedList = swap list
    if swappedList = list then
      list
    else
      loop swappedList

  loop list
