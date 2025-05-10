
using E_Book_Store.BLL.Dtos.OrderDto;
using E_Book_Store.BLL.Dtos.UserDtos;
using E_Book_Store.DAL.Repository.OrderRepository;

namespace E_Book_Store.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderManager _orderManager;

    public OrderController(IOrderManager  orderManager)
    {
        _orderManager = orderManager;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
       var orders = _orderManager.GetAll();
       return  orders == null ? NotFound() : Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _orderManager.GetById(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public IActionResult Add(OrderAddDto orderAddDto)
    {
        _orderManager.insert(orderAddDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id ,OrderUpdateDto orderUpdateDto)
    {
        if(id!=orderUpdateDto.OrderId)
            return BadRequest();
        
        var order = _orderManager.GetById(id);
        
        if (order == null)
                return NotFound();
        
        _orderManager.Update(orderUpdateDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var order = _orderManager.GetById(id);
        _orderManager.Delete(id);
        return Ok($"Order {id} has been deleted");
    }
}