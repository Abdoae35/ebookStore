public class Order
{
    public int OrderId { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public States State { get; set; } = States.Pending;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}