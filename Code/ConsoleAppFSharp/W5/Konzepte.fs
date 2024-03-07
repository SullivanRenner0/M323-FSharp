module Konzepte


let Immutability() = 
    let imutableValue = 10
    // imutableValue <- 20 geht nicht
    ()


let Type_Inference() = 
    let x1 : int = 10
    let x2 = 10
    
    let y1 : float = 10.0
    let y2 = 10.0

    let z1 : string = "10"
    let z2 = "10"

    let t1 : int*float*string = x1, y1, z1
    let t2 = x2, y2, z2
    ()


let Pattern_Matching() = 
    let x = 10

    match x with
    | 0 -> printfn "x is 0"
    | 1 -> printfn "x is 1"
    | _ -> printfn "x is something else"


let Pure_Function x = 
    x + 1


let rec Recursion a b =
    match b with
    | 0 -> a
    | _ -> Recursion b (a % b)


let Anonymous_Functions() = 
    let f = fun name -> printfn "Hello %s" name
    f("Sullivan")

let Higher_Order_Functions (f: int->string) =
    let r = f 10
    ()


let Currying a b = // Currying wird vom Compiler automatisch unterstützt
    a + b

let Currying_Manually a= 
    let subFunction b =
        a + b
    subFunction


let Partial_Application_1 a b =
    a + b

let Partial_Application_2 =
    Partial_Application_1 10

let Partial_Application_3 =
    Partial_Application_2 20


let Closure() = 
    let x = 10
    let f : int->int = fun y -> x + y
    f 20

let Closure_Manually() = 
    let x = 10
    let f1 : int->int->int = fun y z -> y + z
    let f : int->int = f1 x
    f 20