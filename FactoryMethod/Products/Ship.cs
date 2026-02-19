using FactoryMethod.Interfaces;

namespace FactoryMethod.Products;

class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Ship: Deliver by sea in a container.");
    }
}
