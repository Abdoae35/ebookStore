namespace E_Book_Store.BLL.Manager.AccountManager;


    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AccountManager(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager
            ,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
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

        public async Task<string> CreateRole(RoleAddDto roleAddDto)
        {
            IdentityRole role  = new IdentityRole();
            role.Name = roleAddDto.RoleName;
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
                return "Created Successfully";
            return null;
            
        }

        public async Task<string?> AssignRoleToUser(AssignRoleToUserDto assignRoleToUserDto)
        {
            var user = await _userManager.FindByIdAsync(assignRoleToUserDto.UserId); 
            var role = await _roleManager.FindByIdAsync(assignRoleToUserDto.RoleId);
            IdentityError? error;
            if (user!=null && role!=null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name); 
                error = result.Errors.FirstOrDefault();
                if (result.Succeeded)
                {
                    return  "Assigned Successfully";
                }
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

