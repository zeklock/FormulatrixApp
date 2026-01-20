using Delegates;

Console.WriteLine("Events");

Stock stock = new Stock("THPW");
stock.Price = 27.10M;
Console.WriteLine($"Price: {stock.Price}");

stock.PriceChanged += stock_PriceChanged;

stock.Price = 31.59M;
Console.WriteLine($"New Price: {stock.Price}");

void stock_PriceChanged(object? sender, PriceChangedEventArgs e)
{
    if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
        Console.WriteLine("Alert, 10% stock price increase!");
}
