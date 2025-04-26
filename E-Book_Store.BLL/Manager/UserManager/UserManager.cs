


namespace E_Book_Store.BLL.Manager.UserManager;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager( IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public IEnumerable<UserReadDto> GetAll()
    {
        var userReadDtos = _userRepository.GetAllUsers().Select(a => new UserReadDto
        {
            Name = a.Name,
            Email = a.Email,
            Role = a.Role,

        });
        return userReadDtos;
        
    }

    public UserReadDto GetById(int id)
    {
        var user = _userRepository.GetUsersById(id);
        var userDto = new UserReadDto()
        {
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,

        };
        return userDto;
    }

    public void insert(UserAddDto user)
    {
        var model = new User()
        {
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            Phone = user.Phone,
            Address = user.Address,

        };
        _userRepository.insert(model);
    }

    public void Update(UserUpdateDto user)
    {
        var userFromDb = _userRepository.GetUsersById(user.Id);
        if (userFromDb.Name != null)
             userFromDb.Name = user.Name;
        
        if (userFromDb.Email != null)
            userFromDb.Email = user.Email;
        
        if (userFromDb.Phone != null)
            userFromDb.Phone = user.Phone;
        
        if (userFromDb.Address != null)
            userFromDb.Address = user.Address;
        
        _userRepository.Update(userFromDb);
       
    }

    public void Delete(int id)
    {
        var userFromDb = _userRepository.GetUsersById(id);
        _userRepository.Delete(userFromDb);
    }
}