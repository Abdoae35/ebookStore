using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly EbookContext _context;

    public UserRepository(EbookContext  context)
    {
        _context = context;
    }
    public ICollection<User> GetAllUsers()
    {
       var Users = _context.Users.ToList();
       return Users;
    }

    public User GetUsersById(int id)
    {
        var user = _context.Users.Find(id);
        return user ?? null;

    }

    public void insert(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
       _context.Users.Update(user);
       _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}