using EbookFrontEnd.ViewModels.BooksVm;
using EbookFrontEnd.ViewModels.CartVm;
using Microsoft.AspNetCore.Mvc;

namespace EbookFrontEnd.Controllers;

public class CartsController : Controller
{
    private readonly HttpClient _client;

    public CartsController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:5102/");
    }

   
   
    public async Task<IActionResult> AddItemToCart(CartAddVm cartAddVM)
    {
      
        await _client.PostAsJsonAsync($"api/Cart/add", cartAddVM);
        return RedirectToAction(nameof(GetAllItemInCarts));
    }

    public async Task<IActionResult> GetAllItemInCarts()
    {
        var cartItems = await _client.GetFromJsonAsync<List<CartReadVm>>("api/cart/user1");

        return View(cartItems);
    }

    public async Task<IActionResult> RemoveItemFromCart(int id)
    {
        await _client.DeleteAsync($"api/Cart/remove/{id}");
        return RedirectToAction(nameof(GetAllItemInCarts));
    }
}