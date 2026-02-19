using FactoryMethod.Interfaces;

namespace FactoryMethod.Creators;

abstract class Logistics
{
    public abstract ITransport CreateTransport();

    public void PlanDelivery()
    {
        var transport = CreateTransport();
        transport.Deliver();
    }
}
