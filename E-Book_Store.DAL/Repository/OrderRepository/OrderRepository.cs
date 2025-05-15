using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly EbookContext _context;

    public OrderRepository(EbookContext context)
    {
        _context = context;
    }
    public IQueryable<Order> GetAllOrders()
    {
        var orders = _context.Orders;
       return orders;
    }

    public Order GetOrderById(int id)
    {
       var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
       return order;
    }

    public void insert(Order order,OrderBook orderbook)
    {
       _context.Orders.Add(order);
       _context.OrderBooks.Add(orderbook);
       _context.SaveChanges();
    }

    public void Update(Order order)
    {
       _context.Orders.Update(order);
       _context.SaveChanges();
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }
}