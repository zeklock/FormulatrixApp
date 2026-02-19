using FactoryMethod.Interfaces;
using FactoryMethod.Products;

namespace FactoryMethod.Creators;

class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}
