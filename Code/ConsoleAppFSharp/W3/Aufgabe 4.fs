module Aufgabe_4
open System

let CalcRabatt (price:float) : float = 
  match price with
  | price when price >= 200 -> price * 0.9
  | price when price >= 100 -> price * 0.95
  | _ -> price

let CalcMMZ (price:float) : float = 
  match price with
  | price when price < 50 -> price + 10.0
  | _ -> price

let CalcVersandkosten (price:float) : float = 
  match price with
  | price when price < 150 -> price + 20.0
  | _ -> price

let RoundPrice (price:float) : float = 
  Math.Round(price, 2)

let CalcPrice (price:float) : float = 
  price
  |> CalcRabatt
  |> CalcMMZ
  |> CalcVersandkosten
  |> RoundPrice