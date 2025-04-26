namespace E_Book_Store.DAL.Repository.UserRepository;

public interface IUserRepository
{
    public ICollection<User> GetAllUsers();
    public User GetUsersById(int id);
    public void insert(User user);
    public void Update(User user);
    public void Delete(User user);
}