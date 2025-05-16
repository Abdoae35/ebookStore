using E_Book_Store.BLL.Dtos.OrderBookDto;
using E_Book_Store.DAL.Repository.OrderBookRepository;

namespace E_Book_Store.BLL.Manager.OrderBookManager;

public class OrderBookManager : IOrderBookManager
{
    private readonly IOrderBookRepository _orderBookRepository;

    public OrderBookManager(IOrderBookRepository orderBookRepository)
    {
        _orderBookRepository = orderBookRepository;
    }
    public IEnumerable<OrderBookAddDto> GetAll()
    {
      var models  = _orderBookRepository.GetAll().Select(x => new OrderBookAddDto()
      {
          BookId = x.BookId,
          OrderId = x.OrderId,
      });
      return models;
      
    }

    public OrderBookReadDto GetById(int id)
    {
        var  model = _orderBookRepository.GetById(id);
        OrderBookReadDto orderBookReadDto = new OrderBookReadDto()
        {
            BookId = model.BookId,
            OrderId = model.OrderId,
        };
        return orderBookReadDto;

    }

    public void insert(OrderBookAddDto orderBookAddDto)
    {
        var orderBook = new OrderBook()
        {
            BookId = orderBookAddDto.BookId,
            OrderId = orderBookAddDto.OrderId,
        };
        _orderBookRepository.insert(orderBook);
    }

    public void Update(OrderBookUpdateDto orderBookUpdateDto)
    {
       var model = _orderBookRepository.GetById(orderBookUpdateDto.BookId);
       model.BookId = orderBookUpdateDto.BookId;
       model.OrderId = orderBookUpdateDto.OrderId;
       _orderBookRepository.Update(model);
    }

    public void Delete(int id)
    {
        var model = _orderBookRepository.GetById(id);
        _orderBookRepository.Delete(model);
        
    }
}