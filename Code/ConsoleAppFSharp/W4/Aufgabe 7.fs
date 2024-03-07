module Aufgabe_7
open System;

let divide a b = 
  match b with
    | 0.0 -> raise (new DivideByZeroException())
    | _ -> a/b

let rec ggT a b =
  match b
  with
  | 0 -> a
  | _ -> ggT b (a % b)

let asFloat b = 
  let zaehler, nenner = b
  divide zaehler nenner

let kuerze b = 
  let zaehler, nenner = b
  let ggt = ggT zaehler nenner
  (int)(divide zaehler ggt), (int)(divide nenner ggt)

let normiere b = 
  let zaehler, nenner = b
  let norm = match nenner with
              | n when n < 0 -> (-zaehler, -nenner)
              | _ -> (zaehler, nenner)
  kuerze norm

let erweitere b f = 
  let zaehler, nenner = b
  (zaehler*f, nenner*f)

let kehrwert (zaehler, nenner) = 
  kuerze (nenner, zaehler)

let multk b f = 
  let zaehler, nenner = b
  normiere (zaehler*f, nenner*f)

let mult b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  normiere (zaehler1*zaehler2, nenner1*nenner2)

let divk b divisor = 
  let zaehler, nenner = b
  normiere (zaehler, nenner * divisor)

let div b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  normiere (zaehler1*nenner2, nenner1*zaehler2)

let add b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  normiere (zaehler1*nenner2 + zaehler2*nenner1, nenner1*nenner2)

let sub b1 b2 =
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  normiere (zaehler1*nenner2 - zaehler2*nenner1, nenner1*nenner2)



let equal b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 = zaehler2*nenner1

let isGreater b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 > zaehler2*nenner1

let isLess b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 < zaehler2*nenner1

let isGreaterOrEqual b1 b2 = 
  let zaehler1, nenner1 = b1
  let zaehler2, nenner2 = b2
  zaehler1*nenner2 >= zaehler2*nenner1

let isLessOrEqual b1 b2 = 
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

let inline ( / ) b1 b2=
  div b1 b2

let inline ( > ) b1 b2 =
  isGreater b1 b2

let inline ( < ) b1 b2 =
  isLess b1 b2

let inline ( >= ) b1 b2 =
  isGreaterOrEqual b1 b2

let inline ( <= ) b1 b2 =
  isLessOrEqual b1 b2