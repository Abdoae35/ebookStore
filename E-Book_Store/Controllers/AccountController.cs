using E_Book_Store.BLL.Dtos.AccountDto;
using E_Book_Store.BLL.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _account;

        public AccountController(IAccountManager account)
        {
            _account = account;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var result = await _account.Login(loginDto);

            if (result == null)
                return Unauthorized(); 

            return Ok(result);

        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var result = await _account.Regsiter(registerDto);

            if (result == null)
                return Unauthorized();

            return Ok(result);

        }
        [HttpPost("AddNewRole")]
        public async Task<ActionResult>AddRole(RoleAddDto roleAddDto)
        {
            var result = await _account.CreateRole(roleAddDto);
            if (result==null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPost("AssignRoleToUser")]
        public async  Task<ActionResult> AssignRoleToUser(AssignRoleToUserDto assignRoleToUserDto)
        {
            var result = await _account.AssignRoleToUser(assignRoleToUserDto);
            if (result==null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }

    
}
