namespace E_Book_Store.BLL.Dtos.BookDtos;

public class BookUpdateDto
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public string BookUrl { get; set; }
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}