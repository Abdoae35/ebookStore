namespace E_Book_Store.DAL.Models;

public class CartItem
{
    public int Id { get; set; }

    public int CartId { get; set; }
    public Cart Cart { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int Quantity { get; set; }
    public DateTime DateAdded { get; set; }
}