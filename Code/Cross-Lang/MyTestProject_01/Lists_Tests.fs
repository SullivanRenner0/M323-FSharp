namespace MyTestProject_01

open MyFSharpLib_01;
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type Lists_Tests () =

  [<TestMethod>]
  member _.StandardAbweichung_Test() =
    let list = [1.0; 2.0; 3.0; 4.0; 5.0]
    let result = Lists.standardAbweichung list
    Assert.AreEqual(1.4142135623730951, result)

  [<TestMethod>]
  member _.StandardAbweichung_Test_EmptyList() =
    let list = []
    let result = Lists.standardAbweichung list
    Assert.AreEqual(0.0, result)

  [<TestMethod>]
  member _.StandardAbweichung_Test_OneElement() =
    let list = [1.0]
    let result = Lists.standardAbweichung list
    Assert.AreEqual(0.0, result)