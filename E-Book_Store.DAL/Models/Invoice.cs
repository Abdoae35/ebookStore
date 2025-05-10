public class Invoice
{
    public int InvoicesId { get; set; }
   
    
    //softDelete
    public bool IsDeleted { get; set; }
    
    public States State { get; set; }
    
    public User User { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}