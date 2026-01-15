namespace Classes.Partial;

public partial class PaymentForm
{
    // Implementation
    public partial void ValidatePayment(decimal amount)
    {
        Console.WriteLine($"Amount: {amount}");
    }
}
