using E_Book_Store.BLL.Manager.UserManager;
using E_Book_Store.DAL.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace E_Book_Store.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
   private readonly IUserManager _userManager;

   public UserController(IUserManager  userManager)
   {
     _userManager = userManager; 
   }
   
   [HttpGet]
   public IActionResult GetAllUsers()
   {
      var users = _userManager.GetAll();
      return users == null ? NotFound("No User Found") : Ok(users);
   }

   [HttpGet("{id}")]
   public IActionResult GetUserById(int id)
   {
       var user = _userManager.GetById(id);
       return user == null ? NotFound("No User Found") : Ok(user);
   }
   
   
}