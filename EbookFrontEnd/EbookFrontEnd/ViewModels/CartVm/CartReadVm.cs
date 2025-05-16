using EbookFrontEnd.ViewModels.BooksVm;

namespace EbookFrontEnd.ViewModels.CartVm;

public class CartReadVm
{
    
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime DateAdded { get; set; }
    public BookReadVM  Book { get; set; } = null!;
    
}