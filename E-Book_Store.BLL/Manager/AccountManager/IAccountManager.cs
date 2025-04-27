using E_Book_Store.BLL.Dtos.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_Store.BLL.Manager
{
    public interface IAccountManager
    {
        Task<string> Login(LoginDto loginDto);
        Task<string> Regsiter(RegisterDto registerDto);

    }
}
