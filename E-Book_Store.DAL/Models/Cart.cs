namespace E_Book_Store.DAL.Models;

public class Cart 
{
    public int Id { get; set; }

    public string UserId { get; set; }  // to track which user's cart this is

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
   
}