namespace MyTestProject_01

open MyFSharpLib_01;
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member _.TestHello() =
      let result = MyLibrary_01.hello "World"
      Assert.AreEqual("Hello World", result)

    [<TestMethod>]
    member _.TestAdd() =
      let result = MyLibrary_01.add 1.0 2.0
      Assert.AreEqual(3.0, result)

    [<TestMethod>]
    member _.TestSub() =
      let result = MyLibrary_01.sub 2.0 1.0
      Assert.AreEqual(1.0, result)

    [<TestMethod>]
    member _.TestMultiply() =
      let result = MyLibrary_01.multiply 2.0 3.0
      Assert.AreEqual(6.0, result)

    [<TestMethod>]
    member _.TestDivide() =
      let result = MyLibrary_01.divide 6.0 3.0
      Assert.AreEqual(2.0, result)

    [<TestMethod>]
    [<ExpectedException(typeof<System.DivideByZeroException>)>]
    member _.TestDivideByZero() =
      let result = MyLibrary_01.divide 2.0 0.0
      Assert.Fail("Should have thrown DivideByZeroException")

    [<TestMethod>]
    member _.TestOperation_Add() =
      let result = MyLibrary_01.operation 2.0 3.0 MyLibrary_01.add
      Assert.AreEqual(5.0, result)

    [<TestMethod>]
    member _.TestOperation_Sub() =
      let result = MyLibrary_01.operation 2.0 3.0 MyLibrary_01.sub
      Assert.AreEqual(-1.0, result)

    [<TestMethod>]
    member _.TestOperation_Multiply() =
      let result = MyLibrary_01.operation 2.0 3.0 MyLibrary_01.multiply
      Assert.AreEqual(6.0, result)

    [<TestMethod>]
    member _.TestOperation_Divide() =
      let result = MyLibrary_01.operation 6.0 3.0 MyLibrary_01.divide
      Assert.AreEqual(2.0, result)

    [<TestMethod>]
    [<ExpectedException(typeof<System.DivideByZeroException>)>]
    member _.TestOperation_DivideByZero() =
      let result = MyLibrary_01.operation 2.0 0.0 MyLibrary_01.divide
      Assert.Fail("Should have thrown DivideByZeroException")
