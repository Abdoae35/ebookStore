

using E_Book_Store.BLL.Dtos.UserDtos;

namespace E_Book_Store.BLL.Manager.UserManager;

public interface IUserManager
{
    public IEnumerable<UserReadDto> GetAll();
    public UserReadDto GetById(int id);
    public void insert(UserAddDto userAddDto);
    public void Update(UserUpdateDto userUpdateDto);
    public void Delete(int id);
    
}