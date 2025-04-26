public class Payment
{
    public int PaymentId { get; set; }
    public string Type { get; set; } = null!;
    public int CardNumber { get; set; }
    public int CVV { get; set; }
    public DateTime Expiration { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}