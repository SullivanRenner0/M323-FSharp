module Lists_Aufgaben

let upTo n = 
  match n with
  | x when x >= 1 -> [1..x]
  | _ -> []

let downTo n = 
  match n with
  | x when x >= 1 -> [x.. -1 ..1]
  | _ -> []

let rec evenN n =
  match n with
  | x when x <= 0 -> []
  | _ -> evenN (n - 1) @ [2 * n]

let rec rmodd list = 
  match list with
  | [] -> []
  | head :: tail -> 
    if head % 2 = 0 then
      head :: rmodd tail
    else
      rmodd tail

let rec rmeven list = 
  match list with
  | [] -> []
  | head :: tail -> 
    if head % 2 = 0 then
      rmeven tail 
    else
      head :: rmeven tail

let rec mutiplicity x rs = 
  match rs with
  | [] -> 0
  | head :: tail -> 
    if head = x then
      1 + mutiplicity x tail
    else
      mutiplicity x tail

let rec split list = 
  let rec loop arr index evens odds = 
    match arr with
    | [] -> (evens, odds)
    | head :: tail -> 
      if index % 2 = 0 then
        loop tail (index + 1) (head :: evens) odds
      else
        loop tail (index + 1) evens (head :: odds)
  loop list 0 [] []

let zip list1 list2 = 
  let rec loop l1 l2 = 
    match l1, l2 with
    | [], [] -> []
    | head1 :: tail1, head2 :: tail2 -> (head1, head2) :: loop tail1 tail2
    | _, _ -> []
  loop list1 list2

let rec prefix (lst1: 'a list) (lst2: 'a list) : bool when 'a : equality =
  match lst1, lst2 with
  | [], _ -> true
  | _, [] -> false
  | x::xs, y::ys -> x = y && prefix xs ys
