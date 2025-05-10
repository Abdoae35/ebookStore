namespace E_Book_Store.DAL.Repository.OrderRepository;

public interface IOrderRepository
{
    public IQueryable<Order> GetAllOrders();
    public Order GetOrderById(int id);
    public void insert(Order order);
    public void Update(Order order);
    public void Delete(Order order);
}