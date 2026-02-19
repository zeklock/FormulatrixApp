using FactoryMethod.Products;

namespace FactoryMethod.Creators;

class BeforeLogistics
{
    public void PlanDelivery()
    {
        Truck truck = new Truck();
        truck.Deliver();
    }
}
