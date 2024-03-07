module Tuples

let calculateRectangle (length, width) = 
  2 * (length + width), length * width

let printRectangeInfo rect = 
  let umfang, flaeche = rect
  printfn "Umfang: %d" umfang
  printfn "Fläche: %d" flaeche
  0