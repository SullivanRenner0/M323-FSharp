using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class FizzBuzz
{
    public static string[] GetFizzBuzz_1_100() => Enumerable.Range(1, 100).Select(GetFizzBuzz).ToArray();
    public static string GetFizzBuzz(int i)
    {
        var istring = i.ToString();
        var s = "";

        if (i % 3 == 0 || istring.Contains('3'))
            s += "Fizz";

        if (i % 5 == 0 || istring.Contains('5'))
            s += "Buzz";

        if (s == "")
            s = istring;

        return s;
    }
}
