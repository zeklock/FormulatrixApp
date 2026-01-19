using System.Diagnostics.CodeAnalysis;

namespace Inheritance;

public class Baseclass
{
    public int X;
    public Baseclass() { X = 1; }
    public Baseclass(int x) => X = x;
}

// No explicit constructor in Subclass
public class Subclass : Baseclass
{
    // Calls Baseclass(int x) constructor
    public Subclass(int x) : base(x) { }

    // Implicitly calls Baseclass(), so X is 1
    public Subclass() { Console.WriteLine($"X: {X}"); }
}

public class Asset3
{
    // Must be set via object initializer
    public required string Name;

    // This constructor requires 'Name' to be set by object initializer
    public Asset3() { }

    [SetsRequiredMembers]
    // This constructor fulfills the 'required' contract
    public Asset3(string n) => Name = n;
}

public static class ConstructorsInheritance
{
    public static void Main()
    {
        Console.WriteLine("\nConstructors and Inheritance");

        // ILLEGAL: Subclass doesn't have a constructor taking an int
        // Subclass s = new Subclass(123);

        Subclass s = new Subclass();
        Console.WriteLine($"s: {s.X}");

        Asset3 a3 = new Asset3 { Name = "House" };
        Console.WriteLine($"a3 Name: {a3.Name}");
    }
}
