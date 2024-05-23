namespace MyTestProject_01

open MyFSharpLib_01;
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

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
    member _.TestAdd(x, y, expected) =
      let result = MyLibrary_01.add x y
      Assert.AreEqual(expected , result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, -1.0)>]
    [<DataRow(10.0, 2.0, 8.0)>]
    [<DataRow(-1.0, 2.0, -3.0)>]
    [<DataRow(1.0, -2.0, 3.0)>]
    member _.TestSub(x, y, expected) =
      let result = MyLibrary_01.sub x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 2.0)>]
    [<DataRow(10.0, 2.0, 20.0)>]
    [<DataRow(-1.0, 2.0, -2.0)>]
    [<DataRow(1.0, -2.0, -2.0)>]
    member _.TestMultiply(x, y, expected) =
      let result = MyLibrary_01.multiply x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 0.5)>]
    [<DataRow(10.0, 2.0, 5.0)>]
    [<DataRow(-1.0, 2.0, -0.5)>]
    [<DataRow(1.0, -2.0, -0.5)>]
    member _.TestDivide(x, y, expected) =
      let result = MyLibrary_01.divide x y
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    member _.TestDivideByZero() =
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
    member this.TestOperation(x, y, excpected, op) = 
      let func = this.getOperation op
      let result = MyLibrary_01.operation x y func
      Assert.AreEqual(excpected, result)

    [<TestMethod>]
    member _.TestOperation_DivideByZero() =
      try
        let result = MyLibrary_01.operation 2.0 0.0 MyLibrary_01.divide
        Assert.Fail("Should have thrown DivideByZeroException")
      with
      | :? System.DivideByZeroException -> ()
      | x -> Assert.Fail("Should have thrown DivideByZeroException, not " + x.GetType().Name)
