namespace Classes;

public class Methods
{
    // Example of method signatures
    public void Foo(int x) { Console.WriteLine($"x: {x}"); }

    // Different parameter type, different signature
    public void Foo(double x) { Console.WriteLine($"x: {x}"); }

    // Different number of parameters, different signature
    public void Foo(int x, float y)
    {
        Console.WriteLine($"x: {x}, y: {y}");
    }

    // Different order of parameters, different signature
    public void Foo(float x, int y)
    {
        Console.WriteLine($"x: {x}, y: {y}");
    }

    // Expressions-bodied method returning a value
    public int FooValue(int x) => x * 2;

    // Expression-bodied method with void return type
    public void FooVoid(int x) => Console.WriteLine(x);

    // Local method
    public void WriteCubes()
    {
        Console.WriteLine($"Cube 3: {Cube(3)}");

        static int Cube(int value) => value * value * value;
    }
}
