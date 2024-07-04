module Happy_Numbers

let getDigits (n: int) = 
  n
  |> string
  |> Seq.map (fun c -> int (c - '0'))
  |> Seq.toList

let rec IsHappyNumber n tested = 
  if n = 1 then true
  else if List.contains n tested then false
  else
  let sum = getDigits n |> List.map (fun x -> x * x) |> List.sum
  IsHappyNumber sum (n :: tested)

let CheckIsHappyNumber (n: int) : bool = 
  IsHappyNumber n []