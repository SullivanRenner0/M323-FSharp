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

