namespace Classes.Properties;

public class Foo
{
    private decimal x;
    public decimal X
    {
        get { return x; }
        // Private setter
        private set { x = Math.Round(value, 2); }
    }
}
