namespace Generics;

public class GenericTypes
{
    public static void Main()
    {
        Console.WriteLine("\nGeneric Types");

        // Type argument 'int' fills in for 'T'
        var stack = new Stack<int>();
        stack.Push(5);
        stack.Push(10);
        int x = stack.Pop(); // x is 10
        int y = stack.Pop(); // y is 5
        Console.WriteLine($"x: {x}");
        Console.WriteLine($"y: {y}");

        // stack.Push("hello"); // Compile-time error: Cannot push a string onto a Stack<int>
        // var stack = new Stack<>; // Illegal: What is T?
    }
}
