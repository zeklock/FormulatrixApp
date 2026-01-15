using Inheritance.Entities;

namespace Inheritance;

public static class VirtualFunction
{
    public static void Main()
    {
        Console.WriteLine("\nVirtual Function Members");

        House mansion = new House { Name = "McMansion", Mortgage = 250000 };
        Asset a = mansion;
        Console.WriteLine($"mansion.Liability: {mansion.Liability}");
        Console.WriteLine($"a.Liability: {a.Liability}");
    }
}
