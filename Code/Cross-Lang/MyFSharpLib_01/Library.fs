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
      if a = 0.0 then
        raise (new DivideByZeroException())
      else
      let x1 = b * b - (4.0*a*c)
      let x2 = Math.Sqrt(x1)
    
      let x3 = (-b) + x2;
      let x4 = (-b) - x2;
    
      (x3 / (2.0*a), x4 / (2.0*a))
