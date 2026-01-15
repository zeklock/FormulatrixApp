namespace Inheritance;

// Abstract class - cannot be instantiated
abstract class Asset2
{
    public string Name;

    // Abstract property - no implementation here
    public abstract decimal NetValue { get; }
}

class Stock2 : Asset2
{
    public long SharesOwned;
    public decimal CurrentPrice;

    // Must provide implementation
    public override decimal NetValue => CurrentPrice * SharesOwned;
}

public static class AbstractClasses
{
    public static void Main()
    {
        Console.WriteLine("\nAbstract Classes and Abstract Members");

        Stock2 s = new Stock2() { Name = "MSFT", SharesOwned = 1000, CurrentPrice = 500 };
        Console.WriteLine($"Name: {s.Name}");
        Console.WriteLine($"SharesOwned: {s.SharesOwned}");
        Console.WriteLine($"CurrentPrice: {s.CurrentPrice}");
        Console.WriteLine($"NetValue: {s.NetValue}");
    }
}
