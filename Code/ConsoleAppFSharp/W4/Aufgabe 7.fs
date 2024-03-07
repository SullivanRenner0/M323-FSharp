module Aufgabe_7

let kehrwert (zaehler:float, nenner:float) = 
  (nenner, zaehler)

let multk (b: float*float) (f:float) = 
  let zaehler, nenner = b
  (zaehler*f, nenner*f)

let mult (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*zaehler2, nenner1*nenner2)

let divk (b:float*float) (f:float) = 
  let zaehler, nenner = b
  (zaehler/f, nenner)

let div (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2, nenner1*zaehler2)


let asFloat (b:float*float) = 
  let zaehler, nenner = b
  zaehler/nenner

let erweitere (b:float*float) (f:float) = 
  let zaehler, nenner = b
  (zaehler*f, nenner*f)

let kuerze (b:float*float) (f:float) = 
  let zaehler, nenner = b
  (zaehler/f, nenner/f)

let add (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2 + zaehler2*nenner1, nenner1*nenner2)

let sub (b1:float*float) (b2:float*float) =
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2 - zaehler2*nenner1, nenner1*nenner2)

let equal (b1:float*float) (b2:float*float) = 
    asFloat(b1) = asFloat(b2)