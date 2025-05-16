using E_Book_Store.BLL.Dtos.OrderBookDto;

namespace E_Book_Store.BLL.Manager.OrderBookManager;

public interface IOrderBookManager
{
    public IEnumerable<OrderBookAddDto> GetAll();
    public OrderBookReadDto GetById(int id);
    public void insert(OrderBookAddDto orderBookAddDto);
    public void Update(OrderBookUpdateDto orderBookUpdateDto);
    public void Delete(int id);
}