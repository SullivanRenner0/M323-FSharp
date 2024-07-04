using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class Roman
{
    private static readonly Dictionary<char, int> RomanToIntDic = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    public static int FromRomanToInt(string roman)
    {
        var res = 0;

        var last = 0;

        for (var i = roman.Length; i > 0; i--)
        {
            var current = RomanToIntDic[roman[i]];

            res += current > last ? -current : current;

            last = current;
        }

        return res;
    }
}
