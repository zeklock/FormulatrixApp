namespace Classes.Properties;

public class Stock
{
    // The private "backing" field
    decimal currentPrice, sharesOwned;

    // The public property
    public decimal CurrentPrice
    {
        // The get accessor runs when property is read
        get { return currentPrice; }
        // The set accessor runs when property is assigned
        set { currentPrice = value; }
    }

    // Calculated property
    public decimal Worth
    {
        get { return currentPrice * sharesOwned; }
    }

    // Expression-bodied property
    // public decimal Worth => currentPrice * sharesOwned;

    // Automatic property
    // public decimal CurrentPrice { get; set; }
    // public decimal CurrentPrice { get; set; } = 123;
}
