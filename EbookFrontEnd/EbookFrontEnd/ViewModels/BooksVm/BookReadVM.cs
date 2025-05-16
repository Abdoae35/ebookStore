using EbookFrontEnd.ViewModels.CartVm;

namespace EbookFrontEnd.ViewModels.BooksVm;

public class BookReadVM
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string BookUrl { get; set; }
    public string ImageUrl { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
   
   
}