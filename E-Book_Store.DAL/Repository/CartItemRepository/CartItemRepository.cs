using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.CartItemRepository;

public class CartItemRepository : ICartItemRepository
{
    private readonly EbookContext _context;

    public CartItemRepository(EbookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(string userId)
    {
        return await _context.CartItems
            .Include(ci => ci.Book)
            .Where(ci => ci.Cart.UserId == userId)
            .ToListAsync();
    }

    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(CartItem cartItem)
    {
        _context.CartItems.Update(cartItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(int cartItemId)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<CartItem?> GetCartItemByIdAsync(int id)
    {
        return await _context.CartItems
            .Include(ci => ci.Book)
            .FirstOrDefaultAsync(ci => ci.Id == id);
    }

    public async Task<Cart?> GetOrCreateCartAsync(string userId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }
}