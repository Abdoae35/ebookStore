using E_Book_Store.BLL.Dtos.CartItemsDtos;
using E_Book_Store.BLL.Manager.CartItemManager;

namespace E_Book_Store.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartItemServices _cartService;

    public CartController(ICartItemServices cartService)
    {
        _cartService = cartService;
    }

    // GET: api/Cart/user123
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserCart(string userId)
    {
        var cartItems = await _cartService.GetUserCartAsync(userId);
        return Ok(cartItems);
    }

    // POST: api/Cart/add
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartRequestDto request)
    {
        await _cartService.AddToCartAsync(request.BookId, request.UserId);
        return Ok(new { message = "Book added to cart." });
    }

    // PUT: api/Cart/update
    [HttpPut("update")]
    public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemRequestDto request)
    {
        await _cartService.UpdateCartItemAsync(request.CartItemId, request.Quantity);
        return Ok(new { message = "Cart item updated." });
    }

    // DELETE: api/Cart/remove/5
    [HttpDelete("remove/{cartItemId}")]
    public async Task<IActionResult> DeleteCartItem(int cartItemId)
    {
        await _cartService.DeleteCartItemAsync(cartItemId);
        return Ok(new { message = "Cart item removed." });
    }
}