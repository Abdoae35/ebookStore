public class Invoice
{
    public int InvoicesId { get; set; }
   
    
    //softDelete
    public bool IsDeleted { get; set; }
    
    public States State { get; set; }
    
    //one to Many - one user for many invoices
    public int UserId { get; set; }
    public User User { get; set; }
    
    //one to one - one Invoice for one order
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}