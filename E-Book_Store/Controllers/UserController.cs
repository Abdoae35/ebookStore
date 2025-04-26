using E_Book_Store.BLL.Dtos.UserDtos;
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

   [HttpPut]
   public IActionResult Update(int id,UserUpdateDto user)
   {
       if (id != user.Id)
        return BadRequest();
       var userFromDb = _userManager.GetById(id);
       _userManager.Update(user);
       return Ok();
   }

   [HttpPost]
   public IActionResult Add(UserAddDto user)
   {
        _userManager.insert(user);
        return Ok();
   }

   [HttpDelete("{id}")]
   public IActionResult Delete(int id)
   {
       var userFromDb = _userManager.GetById(id);
       _userManager.Delete(id);
       return Ok($"Removed User {userFromDb.Name}");
   }
   
}