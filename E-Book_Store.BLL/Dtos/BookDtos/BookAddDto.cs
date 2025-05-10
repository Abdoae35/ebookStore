namespace E_Book_Store.BLL.Dtos.BookDtos;

public class BookAddDto
{
   
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string BookUrl { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}