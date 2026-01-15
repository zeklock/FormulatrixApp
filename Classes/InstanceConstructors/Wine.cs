namespace Classes.InstanceConstructors;

public class Wine
{
    public decimal Price;
    public int Year;

    public Wine(decimal price) => Price = price;

    // Calls the (decimal price) constructor first
    public Wine(decimal price, int year) : this(price) => Year = year;
}
