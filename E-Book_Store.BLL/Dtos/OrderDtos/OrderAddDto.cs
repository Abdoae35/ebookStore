namespace E_Book_Store.BLL.Dtos.OrderDto;

public class OrderAddDto
{
   
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public States State { get; set; } = States.Pending;
    public int UserId { get; set; }
}