using E_Book_Store.DAL.Repository.CartItemRepository;

namespace E_Book_Store.BLL.Manager.CartItemManager;

public class CartItemServices : ICartItemServices
{
    private readonly ICartItemRepository _cartItemRepo;

    public CartItemServices(ICartItemRepository cartItemRepo)
    {
        _cartItemRepo = cartItemRepo;
    }

    public async Task<IEnumerable<CartItem>> GetUserCartAsync(string userId)
    {
        return await _cartItemRepo.GetCartItemsByUserIdAsync(userId);
    }

    public async Task AddToCartAsync(int bookId, string userId)
    {
        var cart = await _cartItemRepo.GetOrCreateCartAsync(userId);
        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == bookId);

        if (existingItem != null)
        {
            existingItem.Quantity++;
            await _cartItemRepo.UpdateCartItemAsync(existingItem);
        }
        else
        {
            var newItem = new CartItem
            {
                BookId = bookId,
                CartId = cart.Id,
                Quantity = 1,
                DateAdded = DateTime.Now
            };

            await _cartItemRepo.AddCartItemAsync(newItem);
        }
    }

    public async Task UpdateCartItemAsync(int cartItemId, int quantity)
    {
        var item = await _cartItemRepo.GetCartItemByIdAsync(cartItemId);
        if (item != null)
        {
            item.Quantity = quantity;
            await _cartItemRepo.UpdateCartItemAsync(item);
        }
    }

    public async Task DeleteCartItemAsync(int cartItemId)
    {
        await _cartItemRepo.DeleteCartItemAsync(cartItemId);
    }
}