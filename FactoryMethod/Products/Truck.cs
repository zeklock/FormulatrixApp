using FactoryMethod.Interfaces;

namespace FactoryMethod.Products;

class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Truck: Deliver by land in a box.");
    }
}
