module Aufgabe_5

let Add (a:float) (b:float) : float = 
  a + b

let Sub (a:float) (b:float) : float = 
  a - b

let Mul (a:float) (b:float) : float =
  a * b

let Div (a:float) (b:float) : float =
  match b with
  | 0.0 -> 0.0
  | _ -> a / b

let Calc1 (f) (a:float) (b:float) : float = 
  f a b

let Calc2 (fName:string) =
  match fName with
  | "add" -> Some(Add)
  | "sub" -> Some(Sub)
  | "mul" -> Some(Mul)
  | "div" -> Some(Div)
  | _ -> None

let Calc3 (fName:string, a:float, b:float) : float = 
  match Calc2(fName) with
  | Some(f) -> Calc1 f a b
  | None -> 0.0