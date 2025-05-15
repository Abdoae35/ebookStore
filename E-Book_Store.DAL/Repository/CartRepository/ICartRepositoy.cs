namespace E_Book_Store.DAL.Repository.CartRepository;

public interface ICartRepositoy
{
    public IQueryable<Cart> GetAllItems();
    public Cart GetById(int id);
    public void insert(Cart cart);
    public void Update(Cart cart);
    public void Delete(Cart cart);
}