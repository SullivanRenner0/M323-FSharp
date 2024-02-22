module Aufgabe_6
open System

let Addiere a b c =
  a + b + c

let AddPartial1 = 
  Addiere 1

let AddPartial2 = 
  AddPartial1 2

let AddPartial3 = 
  AddPartial2 3


let CalcCoinValue (radius:float) (thickness:float) (density:float) (price:float) =
  let volume = radius**2 * Math.PI * thickness
  volume * density * price

let CalcCoinValueFixedSize =
  CalcCoinValue 1.0 1.0

let CalcCoinValueFixedSizeGold =
  CalcCoinValueFixedSize 19.32

let CalcCoinValueFixedSizeSilver =
  CalcCoinValueFixedSize 10.49

let CoinValueFixedSizeFixedPriceGold =
  CalcCoinValueFixedSizeGold 1780.87

let CoinValueFixedSizeFixedPriceSilver =
  CalcCoinValueFixedSizeSilver 20.06