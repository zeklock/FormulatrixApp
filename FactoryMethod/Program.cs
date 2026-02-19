using FactoryMethod.Creators;

namespace FactoryMethod;

class Program
{
    static void Main()
    {
        Console.WriteLine("Factory Method");

        BeforeFactoryMethod();
        AfterFactoryMethod();
    }

    static void BeforeFactoryMethod()
    {
        Console.WriteLine("\nBefore Factory Method");

        BeforeLogistics logistics = new BeforeLogistics();
        logistics.PlanDelivery();
    }

    static void AfterFactoryMethod()
    {
        Console.WriteLine("\nAfter Factory Method");

        Logistics logistics;

        logistics = new RoadLogistics();
        logistics.PlanDelivery();

        logistics = new SeaLogistics();
        logistics.PlanDelivery();
    }
}
