namespace E_Book_Store.BLL.Dtos.OrderBookDto;

public class OrderBookUpdateDto
{
    public int OrderId { get; set; } 
    public Order Order { get; set; } = null!;

    public int BookId { get; set; } 
    public Book Book { get; set; } = null!;
}