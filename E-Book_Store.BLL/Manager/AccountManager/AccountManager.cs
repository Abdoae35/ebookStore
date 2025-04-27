using E_Book_Store.BLL.Dtos.AccountDto;
using E_Book_Store.BLL.Manager.UserManager;
using E_Book_Store.DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_Store.BLL.Manager
{

    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _configuration;


        public AccountManager(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Name);

            if (user == null)
                return null;

            var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (check == false)
                return null;

            var claims = await _userManager.GetClaimsAsync(user);

            return GenerateToken(claims);


        }

        public async Task<string> Regsiter(RegisterDto registerDto)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = registerDto.Email;
            user.UserName = registerDto.Name;

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {

                // if successful we create token but create claims first
                var claims = new List<Claim>();
                claims.Add(new Claim("Role", "Admin"));
                claims.Add(new Claim("Name", registerDto.Name));

                await _userManager.AddClaimsAsync(user, claims);

                string token = GenerateToken(claims);

                return token;

            }

            return null;


        }

        public string GenerateToken(IList<Claim> claims)
        {
            var SecretKey = _configuration.GetSection("SecretKey").Value;

            var SecretKeyByte = Encoding.UTF8.GetBytes(SecretKey);

            SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expire = DateTime.UtcNow.AddDays(5);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
