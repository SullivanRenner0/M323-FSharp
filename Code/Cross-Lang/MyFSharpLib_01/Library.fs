namespace MyFSharpLib_01

open System;

module MyLibrary_01 =
    let hello name =
        "Hello " + name

    let add x y : float = 
      x + y

    let sub x y : float =
      x - y

    let multiply x y : float =
      x * y

    let divide x y : float =
      match y with
      | 0.0 -> raise (new DivideByZeroException())
      | _ -> x / y

    let operation x y op = 
      op x y

    let mitternacht a b c =
      let x1 = b * b - (4.0*a*c)

      if x1 < 0.0 then
        []
      else 
      
      if a = 0.0 then
        raise (new DivideByZeroException())
      else

      if x1 = 0.0 then
        [-b / (2.0*a)] // (-b +- 0) / 2a
      else

      let x2 = Math.Sqrt(x1)
      
      let x3 = (-b) + x2;
      let x4 = (-b) - x2;
    
      [x3 / (2.0*a); x4 / (2.0*a)]

    type Produkt = {Name:string; Preis: float; Anzverkauft : int}

    let list = [{Name = "T1"; Preis = 1.0; Anzverkauft = 1};{Name = "T2"; Preis = 2.0; Anzverkauft = 2};{Name = "T3"; Preis = 3.0; Anzverkauft = 3}]

    let rec sumProduktPreise (list:Produkt list) = 
      match list with
      | [] -> []
      | head :: tail ->
        (head.Name, head.Preis * float(head.Anzverkauft)) :: (sumProduktPreise tail)

    let rec sumProduktPreiseAbove_100_000 (list:Produkt list) = 
      match list with
      | [] -> []
      | head :: tail ->
        let rest = sumProduktPreise tail
        let sum = head.Preis * float(head.Anzverkauft)
        if sum >= 100_000 then
          (head.Name, sum) :: rest
        else
          rest

    let rec getGesamtSumme (list : Produkt list) = 
      match list with
      | [] -> 0.0
      | head :: tail ->
        head.Preis * float(head.Anzverkauft) + (getGesamtSumme tail)

    let rec applyFaktor (list : Produkt list) (faktor : float) = 
      match list with 
      | [] -> []
      | head :: tail ->
        let rest = (applyFaktor tail faktor)
        let newElement = (head.Name, head.Preis * faktor, head.Preis * faktor * float(head.Anzverkauft))
        newElement :: rest