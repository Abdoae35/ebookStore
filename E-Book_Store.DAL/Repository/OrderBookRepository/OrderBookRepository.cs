using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.OrderBookRepository;

public class OrderBookRepository : IOrderBookRepository
{
    private readonly EbookContext _context;

    public OrderBookRepository(EbookContext context)
    {
        _context = context;
    }
    public IQueryable<OrderBook> GetAll()
    {
        return _context.OrderBooks.AsNoTracking();
    }

    public OrderBook? GetById(int id)
    {
        var orderBook = _context.OrderBooks.Find(id);
        if (orderBook == null)
            return null;
        return orderBook;
    }

    public void insert(OrderBook orderBook)
    {
        _context.OrderBooks.Add(orderBook);
        _context.SaveChanges();
    }

    public void Update(OrderBook orderBook)
    {
        _context.SaveChanges();
    }

    public void Delete(OrderBook orderBook)
    {
        _context.OrderBooks.Remove(orderBook);
        _context.SaveChanges();
    }
}