module Aufgabe_2

let rec Fakultaet n = 
  match n
  with
  | 0 -> 1
  | _ -> n * Fakultaet(n - 1)

let rec Fibonacci n =
  match n
  with
  | 0 -> 0
  | 1 -> 1
  | _ -> Fibonacci(n - 1) + Fibonacci(n - 2)

let rec ggT a b =
  match b
  with
  | 0 -> a
  | _ -> ggT b (a % b)

let kgV a b = a * b / ggT a b