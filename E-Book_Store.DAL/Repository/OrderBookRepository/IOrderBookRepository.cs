namespace E_Book_Store.DAL.Repository.OrderBookRepository;

public interface IOrderBookRepository
{
    public IQueryable<OrderBook> GetAll();
    public OrderBook GetById(int id);
    public void insert(OrderBook orderBook);
    public void Update(OrderBook orderBook);
    public void Delete(OrderBook orderBook);
}