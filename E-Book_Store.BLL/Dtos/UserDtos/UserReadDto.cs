namespace E_Book_Store.BLL.Dtos.UserDtos;

public class UserReadDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
   
}