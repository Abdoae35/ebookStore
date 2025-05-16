using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.CartRepository;

public class CartRepository :  ICartRepositoy
{
    private readonly EbookContext _context;

    public CartRepository(EbookContext context)
    {
        _context = context;
    }

    public IQueryable<Cart> GetAllItems()
    {
       var models= _context.Carts;
       return models;
    }

    public Cart? GetById(int id)
    {
       return _context.Carts.Find(id);
    }

    public void insert(Cart cart)
    {
       _context.Carts.Add(cart);
       _context.SaveChanges();
    }

    public void Update(Cart cart)
    {
       _context.Carts.Update(cart);
       _context.SaveChanges();
    }

    public void Delete(Cart cart)
    {
       _context.Carts.Remove(cart);
       _context.SaveChanges();
    }
}