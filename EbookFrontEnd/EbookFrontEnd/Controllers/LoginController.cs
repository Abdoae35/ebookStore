using EbookFrontEnd.ViewModels.LogInVm;
using Microsoft.AspNetCore.Mvc;

namespace EbookFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri("http://localhost:5102");
        }

        // GET method for loading the login view
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST method for handling login logic
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            var login = await _httpClient.PostAsJsonAsync("/api/Account/login", loginVm);
            return RedirectToAction(nameof(Logout)); // Redirect to the Logout action after successful login
        }

        // Logout action
        public IActionResult Logout()
        {
            return View();
        }

        public ActionResult Register()
        {
            return PartialView(nameof(Register)); // or just "Register" if this is a full view
        }

        // POST: Login/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterAddVm model)
        {
            if (ModelState.IsValid)
            {
                // Process registration
                // Validate passwords match
                // Create user account
                // Redirect or return success message
                
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}