namespace E_Book_Store.DAL.Repository.CartItemRepository;

public interface ICartItemRepository
{
    Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(string userId);
    Task AddCartItemAsync(CartItem cartItem);
    Task UpdateCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(int cartItemId);
    Task<CartItem?> GetCartItemByIdAsync(int id);
    Task<Cart?> GetOrCreateCartAsync(string userId);
}
