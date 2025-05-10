using E_Book_Store.BLL.Dtos.OrderDto;
using E_Book_Store.DAL.Repository.OrderRepository;

namespace E_Book_Store.BLL.Manager.OrderManager;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository  orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public IEnumerable<OrderReadDto> GetAll()
    {
        var orders = _orderRepository.GetAllOrders().Select(a => new OrderReadDto
        {
            Date = a.Date,
            Price = a.Price,
            State = a.State,
            UserId = a.UserId
        }).ToList();
        
        return orders;
        
    }

    public OrderReadDto GetById(int id)
    {
        var order = _orderRepository.GetOrderById(id);
        var orderDto = new OrderReadDto()
        {
            Date = order.Date,
            Price = order.Price,
            State = order.State,
            UserId = order.UserId
        };
        return orderDto;


    }

    public void insert(OrderAddDto orderAddDto)
    {
        var order = new Order()
        {
            Date = orderAddDto.Date,
            Price = orderAddDto.Price,
            State = orderAddDto.State,
            UserId = orderAddDto.UserId

        };
        _orderRepository.insert(order);
    }

    public void Update(OrderUpdateDto orderUpdateDto)
    {
        var orderModel = _orderRepository.GetOrderById(orderUpdateDto.OrderId);
        
        orderModel.Price = orderUpdateDto.Price;
        orderModel.State = orderUpdateDto.State;
        
        _orderRepository.Update(orderModel);
    }

    public void Delete(int id)
    {
       var orderModel = _orderRepository.GetOrderById(id);
       _orderRepository.Delete(orderModel);
    }
}