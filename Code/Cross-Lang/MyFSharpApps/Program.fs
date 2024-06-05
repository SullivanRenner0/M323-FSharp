// For more information see https://aka.ms/fsharp-console-apps

open System;
open MyFSharpLib_01;

let printSomeText() = 
  let text = "Hello World"
  printfn "text = %s" text

let showCommandLineArgs() = 
  for arg in System.Environment.GetCommandLineArgs() do
    printfn "arg = %s" arg

[<EntryPoint>]
let main args = 
  //printfn "Arguments: %A" args

  //printSomeText()
  //showCommandLineArgs()

  let three = MyLibrary_01.add 1.0 2.0
  printfn "1.0 + 2.0 = %f" three

  let minustwo = MyLibrary_01.sub 1.0 3.0
  printfn "1.0 - 3.0 = %f" minustwo

  let six = MyLibrary_01.multiply 2.0 3.0
  printfn "2.0 * 3.0 = %f" six

  let four = MyLibrary_01.divide 8.0 2.0
  printfn "8.0 / 2.0 = %f" four

  try
    let result = MyLibrary_01.divide 2.0 0.0
    printfn "This will no be printed"
  with
  | :? System.DivideByZeroException -> printfn "DivideByZeroException thrown"
  | x -> printfn "Exception thrown: %s" x.Message

  0 // return an integer exit code
