public class Order :BaseEntity
{
    public int OrderId { get; set; }
   
    public decimal Price { get; set; }
    public States State { get; set; } = States.Pending;
    public int UserId { get; set; }
    public User User { get; set; }
    
    //many to many 
    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    
    //one to one - one order for one invoices
    public Invoice Invoice { get; set; }
    
}