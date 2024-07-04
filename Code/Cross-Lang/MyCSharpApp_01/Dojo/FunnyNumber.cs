using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class FunnyNumber
{
    public static bool IsFunny(int num) => IsFunny(num, []);

    private static bool IsFunny(int num, HashSet<int> tested)
    {
        if (num == 1)
            return true;
        if (tested.Contains(num))
            return false;

        var sum = num.ToString()
            .Select(c => c - '0')
            .Select(d => d * d)
            .Sum();

        tested.Add(sum);
        return IsFunny(sum, tested);
    }
}
