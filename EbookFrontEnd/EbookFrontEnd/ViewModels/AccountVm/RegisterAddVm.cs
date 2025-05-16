using EbookFrontEnd.Enums;

namespace EbookFrontEnd.ViewModels.LogInVm;

public class RegisterAddVm
{
    public string Username { get; set; }
    public string password { get; set; }
    public string ConfirmPassword { get; set; }
    public Role Role { get; set; }

}