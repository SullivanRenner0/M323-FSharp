module Kapitel_3

type Money = {Pound: int; Shilling: int; Pence: int}

let createMoney (p: int) (s: int) (pence: int) = 
    {Pound = p; Shilling = s; Pence = pence}

let PenceToShilling (p: int) : (int*int)= 
    let shilling = p / 12
    let pence = p % 12
    (shilling, pence)

let ShillingToPence s = 
    s * 12

let ShillingToPound s =
    let pound = s / 20
    let shilling = s % 20
    (pound, shilling)

let PoundToShilling p= 
    p * 20

let MoneyToPence m = 
    let poundPence = PoundToShilling(m.Pound) |> ShillingToPence
    let shillingPence = ShillingToPence(m.Shilling)
    let pence = m.Pence
    poundPence + shillingPence + pence

let PenceToMoney p  =
    let penceShilling, pence = PenceToShilling p
    let pound, shilling = ShillingToPound penceShilling 
    createMoney pound shilling pence

let PrintMoney m = 
    printfn "%d Pound, %d Shilling, %d Pence" m.Pound m.Shilling m.Pence

let Add m1 m2 : Money=
    let pence1 = MoneyToPence m1
    let pence2 = MoneyToPence m2
    PenceToMoney (pence1 + pence2)

let Subtract m1 m2 : Money= 
    let pence1 = MoneyToPence m1
    let pence2 = MoneyToPence m2
    PenceToMoney (pence1 - pence2)

let Equal m1 m2= 
    let pence1 = MoneyToPence m1
    let pence2 = MoneyToPence m2
    pence1 = pence2

let GreaterThan m1 m2 = 
    let pence1 = MoneyToPence m1
    let pence2 = MoneyToPence m2
    pence1 > pence2

let LessThan m1 m2 = 
    let pence1 = MoneyToPence m1
    let pence2 = MoneyToPence m2
    pence1 < pence2

let GreaterThanOrEqual m1 m2 = 
    not (LessThan m1 m2)

let LessThanOrEqual m1 m2 : bool= 
    not (GreaterThan m1 m2)


let (+) m1 m2 =
    Add m1 m2

let (-) m1 m2 =
    Subtract m1 m2

let (=) m1 m2 =
    Equal m1 m2

let (<>) m1 m2 =
    not (m1 = m2)

let (<) m1 m2 =
    LessThan m1 m2

let (>) m1 m2 =
    GreaterThan m1 m2

let (<=) m1 m2 = 
    GreaterThanOrEqual m1 m2

let (>=) m1 m2 = 
    LessThanOrEqual m1 m2