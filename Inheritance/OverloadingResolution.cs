using Inheritance.Entities;

namespace Inheritance;

public static class OverloadingResolution
{
    public static void Main()
    {
        Console.WriteLine("\nOverloading and Resolution");

        House h = new House();
        Foo(h);

        Asset a = new Asset();
        Foo(a);
        Foo((dynamic)a);
    }

    static void Foo(Asset a) { Console.WriteLine("Foo(Asset)"); }

    static void Foo(House h) { Console.WriteLine("Foo(House)"); }
}
