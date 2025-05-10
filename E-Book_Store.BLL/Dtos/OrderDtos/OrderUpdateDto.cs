namespace E_Book_Store.BLL.Dtos.OrderDto;

public class OrderUpdateDto
{
    public int OrderId { get; set; }
    public decimal Price { get; set; }
    public States State { get; set; } = States.Pending;
   
}