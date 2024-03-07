module Aufgabe_7

let divide a b = 
  match b with
    | 0.0 -> 0.0
    | _ -> a/b

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
  (divide zaehler f, nenner)

let div (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2, nenner1*zaehler2)


let asFloat (b:float*float) = 
  let zaehler, nenner = b
  divide zaehler nenner

let erweitere (b:float*float) (f:float) = 
  let zaehler, nenner = b
  (zaehler*f, nenner*f)

let kuerze (b:float*float) (f:float) = 
  let zaehler, nenner = b
  (divide zaehler f, divide nenner f)

let add (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2 + zaehler2*nenner1, nenner1*nenner2)

let sub (b1:float*float) (b2:float*float) =
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  (zaehler1*nenner2 - zaehler2*nenner1, nenner1*nenner2)

let equal (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 = zaehler2*nenner1

let isGreater (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 > zaehler2*nenner1

let isLess (b1:float*float) (b2:float*float) =
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 < zaehler2*nenner1

let isGreaterOrEqual (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 >= zaehler2*nenner1

let isLessOrEqual (b1:float*float) (b2:float*float) = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 <= zaehler2*nenner1


let inline ( = ) b1 b2 =
  equal b1 b2

let inline ( != ) b1 b2 =
  not (equal b1 b2)

let inline ( + ) b1 b2 =
  add b1 b2

let inline ( - ) b1 b2 =
  sub b1 b2

let inline ( * ) b1 b2 =
  mult b1 b2

let inline ( / ) b1 b2 =
  div b1 b2
  
let inline ( > ) b1 b2 =
  isGreater b1 b2

let inline ( < ) b1 b2 =
  isLess b1 b2

let inline ( >= ) b1 b2 =
  isGreaterOrEqual b1 b2

let inline ( <= ) b1 b2 =
  isLessOrEqual b1 b2