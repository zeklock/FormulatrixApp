namespace Inheritance.Entities;

// Base Class
public class Asset
{
    public string Name;

    // Virtual property with a default implementation
    public virtual decimal Liability => 0;
    // Return Asset
    public virtual Asset Clone() => new Asset { Name = Name };
}
