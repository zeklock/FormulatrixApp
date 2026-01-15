using Inheritance.Entities;

namespace Inheritance;

public static class Inheritance
{
    static Stock msft;
    static House mansion;

    public static void Main()
    {
        Console.WriteLine("\nInheritance");

        msft = new Stock { Name = "MSFT", SharesOwned = 1000 };
        Console.WriteLine($"Name: {msft.Name}");
        Console.WriteLine($"SharesOwned: {msft.SharesOwned}");

        mansion = new House { Name = "Mansion", Mortgage = 250000 };
        Console.WriteLine($"Name: {mansion.Name}");
        Console.WriteLine($"Mortgage: {mansion.Mortgage}");

        // Polymorphism();
        // Upcasting();
        // Downcasting();
        AsIsOperator();

    }

    static void Polymorphism()
    {
        Console.WriteLine("\nPolymorphism");

        static void Display(Asset asset)
        {
            Console.WriteLine($"Name: {asset.Name}");
        }

        Display(msft);
        Display(mansion);
    }

    static void Upcasting()
    {
        Console.WriteLine("\nUpcasting");

        Asset a = msft;
        Console.WriteLine($"Name: {a.Name}");
    }

    static void Downcasting()
    {
        Console.WriteLine("\nDowncasting");

        Asset a = msft;
        Stock s = (Stock)a;
        Console.WriteLine($"SharesOwned: {s.SharesOwned}");
        Console.WriteLine($"s == a: {s == a}");
        Console.WriteLine($"s == msft: {s == msft}");
    }

    static void AsIsOperator()
    {
        Console.WriteLine("\nAsIsOperator");

        Asset a = new Asset();
        Stock s = a as Stock;

        if (s != null)
            Console.WriteLine($"Name: {s.SharesOwned}");

        if (a is Stock)
            Console.WriteLine($"((Stock)a).SharesOwned: {((Stock)a).SharesOwned}");

        if (a is Stock s2)
            Console.WriteLine($"s2.SharesOwned: {s2.SharesOwned}");
    }
}
