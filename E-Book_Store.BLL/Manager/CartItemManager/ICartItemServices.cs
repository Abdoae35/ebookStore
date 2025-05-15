namespace E_Book_Store.BLL.Manager.CartItemManager;

public interface ICartItemServices
{
    Task<IEnumerable<CartItem>> GetUserCartAsync(string userId);
    Task AddToCartAsync(int bookId, string userId);
    Task UpdateCartItemAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}