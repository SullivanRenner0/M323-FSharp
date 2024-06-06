namespace MyTestProject_01

open System;
open MyFSharpLib_01;
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type MyLibrary_01_Tests () =

    [<TestMethod>]
    [<DataRow("World", "Hello World")>]
    member _.TestHello(input, expected) =
      let result = MyLibrary_01.hello input
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 3.0)>]
    [<DataRow(10.0, 2.0, 12.0)>]
    [<DataRow(-1.0, 2.0, 1.0)>]
    [<DataRow(1.0, -2.0, -1.0)>]
    member _.Add_Test(x, y, expected) =
      let result = MyLibrary_01.add x y
      Assert.AreEqual(expected , result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, -1.0)>]
    [<DataRow(10.0, 2.0, 8.0)>]
    [<DataRow(-1.0, 2.0, -3.0)>]
    [<DataRow(1.0, -2.0, 3.0)>]
    member _.Sub_Test(x, y, expected) =
      let result = MyLibrary_01.sub x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 2.0)>]
    [<DataRow(10.0, 2.0, 20.0)>]
    [<DataRow(-1.0, 2.0, -2.0)>]
    [<DataRow(1.0, -2.0, -2.0)>]
    member _.Multiply_Test(x, y, expected) =
      let result = MyLibrary_01.multiply x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 0.5)>]
    [<DataRow(10.0, 2.0, 5.0)>]
    [<DataRow(-1.0, 2.0, -0.5)>]
    [<DataRow(1.0, -2.0, -0.5)>]
    member _.Divide_Test(x, y, expected) =
      let result = MyLibrary_01.divide x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    member _.Divide_ByZero_Test() =
      try
        let result = MyLibrary_01.divide 2.0 0.0
        Assert.Fail("Should have thrown DivideByZeroException")
      with
      | :? System.DivideByZeroException -> ()
      | x -> Assert.Fail("Should have thrown DivideByZeroException, not " + x.GetType().Name)


    // Test operation function
    member _.getOperation op = 
      match op with
      | "add" -> MyLibrary_01.add
      | "sub" -> MyLibrary_01.sub
      | "multiply" -> MyLibrary_01.multiply
      | "divide" -> MyLibrary_01.divide
      | _ -> failwith "Invalid operation"

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 3.0, "add")>]
    [<DataRow(10.0, 2.0, 12.0, "add")>]
    [<DataRow(-1.0, 2.0, 1.0, "add")>]
    [<DataRow(1.0, -2.0, -1.0, "add")>]
    [<DataRow(1.0, 2.0, -1.0, "sub")>]
    [<DataRow(10.0, 2.0, 8.0, "sub")>]
    [<DataRow(-1.0, 2.0, -3.0, "sub")>]
    [<DataRow(1.0, -2.0, 3.0, "sub")>]
    [<DataRow(1.0, 2.0, 2.0, "multiply")>]
    [<DataRow(10.0, 2.0, 20.0, "multiply")>]
    [<DataRow(-1.0, 2.0, -2.0, "multiply")>]
    [<DataRow(1.0, -2.0, -2.0, "multiply")>]
    [<DataRow(1.0, 2.0, 0.5, "divide")>]
    [<DataRow(10.0, 2.0, 5.0, "divide")>]
    [<DataRow(-1.0, 2.0, -0.5, "divide")>]
    [<DataRow(1.0, -2.0, -0.5, "divide")>]
    member this.Operation_Test(x, y, excpected, op) = 
      let func = this.getOperation op
      let result = MyLibrary_01.operation x y func
      Assert.AreEqual(excpected, result)

    [<TestMethod>]
    member _.Operation_Divide_ByZero_Test() =
      try
        let result = MyLibrary_01.operation 2.0 0.0 MyLibrary_01.divide
        Assert.Fail("Should have thrown DivideByZeroException")
      with
      | :? System.DivideByZeroException -> ()
      | x -> Assert.Fail("Should have thrown DivideByZeroException, not " + x.GetType().Name)
    

    [<DataRow(3, 9, 6, -1, -2)>]
    [<TestMethod>]
    member _.Mitternacht_Test_TwoResults(a :float, b:float, c:float, expected1 : float, expected2 :float) = 
      let resultat = MyLibrary_01.mitternacht a b c
      Assert.AreEqual(resultat, [expected1; expected2])

    [<DataRow(2, 4, 2, -1)>]
    [<TestMethod>]
    member _.Mitternacht_Test_OneResults(a :float, b:float, c:float, expected : float) = 
      let resultat = MyLibrary_01.mitternacht a b c
      Assert.AreEqual(resultat, [expected])

    [<DataRow(4, 4, 4)>]
    [<TestMethod>]
    member _.Mitternacht_Test_NoResults(a :float, b:float, c:float) = 
      let resultat = MyLibrary_01.mitternacht a b c
      Assert.AreEqual(resultat, [])

    [<TestMethod>]
    member _.Mitternacht_Divide_ByZero_Test() =
      try
        let result = MyLibrary_01.mitternacht 0 10 10
        Assert.Fail("Should have thrown DivideByZeroException")
      with
      | :? DivideByZeroException -> ()
      | x -> Assert.Fail("Should have thrown DivideByZeroException, not " + x.GetType().Name)
