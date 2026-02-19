using FactoryMethod.Interfaces;
using FactoryMethod.Products;

namespace FactoryMethod.Creators;

class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}
