namespace Generics;

public class GenericMethods
{
    public static void Main()
    {
        Console.WriteLine("\nGeneric Methods");

        int x = 5;
        int y = 10;
        // Compiler infers T is int
        Swap(ref x, ref y);
        Console.WriteLine($"x: {x}");
        Console.WriteLine($"y: {y}");
    }

    // Declares type parameter T
    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}
