using System;
using System.Linq;

namespace MyCSharpApp_01.Dojo;
internal class Bauernmultiplikation
{
    public static int Multiply(int a, int b)
    {
        var result = 0;
        while (a > 0)
        {
            if (a % 2 == 1)
                result += b;
            a = a / 2;
            b *= 2;
        }
        return result;
    }
}
