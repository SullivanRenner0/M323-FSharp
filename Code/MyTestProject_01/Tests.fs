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
    [<ExpectedException(typeof<System.DivideByZeroException>)>]
    member _.TestDivideByZero() =
      let result = MyLibrary_01.divide 2.0 0.0
      Assert.Fail("Should have thrown DivideByZeroException")


    // Test operation function

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 3.0)>]
    [<DataRow(10.0, 2.0, 12.0)>]
    [<DataRow(-1.0, 2.0, 1.0)>]
    [<DataRow(1.0, -2.0, -1.0)>]
    member _.TestOperation_Add(x, y, expected) = 
      let result = MyLibrary_01.operation x y MyLibrary_01.add
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, -1.0)>]
    [<DataRow(10.0, 2.0, 8.0)>]
    [<DataRow(-1.0, 2.0, -3.0)>]
    [<DataRow(1.0, -2.0, 3.0)>]
    member _.TestOperation_Sub(x, y, expected) =
      let result = MyLibrary_01.operation x y MyLibrary_01.sub
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 2.0)>]
    [<DataRow(10.0, 2.0, 20.0)>]
    [<DataRow(-1.0, 2.0, -2.0)>]
    [<DataRow(1.0, -2.0, -2.0)>]
    member _.TestOperation_Multiply(x, y, expected) =
      let result = MyLibrary_01.operation x y MyLibrary_01.multiply
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<DataRow(1.0, 2.0, 0.5)>]
    [<DataRow(10.0, 2.0, 5.0)>]
    [<DataRow(-1.0, 2.0, -0.5)>]
    [<DataRow(1.0, -2.0, -0.5)>]
    member _.TestOperation_Divide(x, y, expected) =
      let result = MyLibrary_01.operation x y MyLibrary_01.divide
      Assert.AreEqual(expected, result)

    [<TestMethod>]
    [<ExpectedException(typeof<System.DivideByZeroException>)>]
    member _.TestOperation_DivideByZero() =
      let result = MyLibrary_01.operation 2.0 0.0 MyLibrary_01.divide
      Assert.Fail("Should have thrown DivideByZeroException")
