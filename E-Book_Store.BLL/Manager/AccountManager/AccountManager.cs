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
                claims.Add(new Claim("Email", registerDto.Email));

                await _userManager.AddClaimsAsync(user, claims);

                string token = GenerateToken(claims);

                return token;

            }

            return null;


        }

       private string GenerateToken(IList<Claim> claims)
            {
                
            var secretKeyString = _configuration.GetSection("SecretKey").Value;
            var secretKeyByte = Encoding.UTF8.GetBytes(secretKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(secretKeyByte);
            
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var expiration = DateTime.UtcNow.AddDays(5);
            JwtSecurityToken  jwtSecurityToken = new JwtSecurityToken(claims:claims,expires: expiration,signingCredentials: credentials);
            
             
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string Token = handler.WriteToken(jwtSecurityToken);
            return Token;
            }
    }
}
