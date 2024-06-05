namespace MyCSharpApp_01;

using MyFSharpLib_01;

internal class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var three = MyLibrary_01.add(1, 2);
        Console.WriteLine("1 + 2 = " + three);

        var minusOne = MyLibrary_01.sub(1, 3);
        Console.WriteLine("1 - 3 = " + minusOne);

        var six = MyLibrary_01.multiply(2, 3);
        Console.WriteLine("2 * 3 = " + six);

        var four = MyLibrary_01.divide(8, 2);
        Console.WriteLine("8 / 2 = " + four);

        try
        {
            MyLibrary_01.divide(2, 0);
            Console.WriteLine("This line will not be printed.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("DivideByZeroException thrown");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception thrown:" + e.Message);
        }

        return 0;
    }
}
