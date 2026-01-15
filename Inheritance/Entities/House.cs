namespace Inheritance.Entities;

// House also inherits from Asset
public class House : Asset
{
    public decimal Mortgage;

    // House overrides Liability
    public override decimal Liability => Mortgage;
    // Return House (which is an Asset)
    public override House Clone() => new House { Name = Name, Mortgage = Mortgage };
}
