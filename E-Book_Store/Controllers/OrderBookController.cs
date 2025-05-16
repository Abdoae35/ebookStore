using E_Book_Store.BLL.Dtos.OrderBookDto;
using E_Book_Store.BLL.Manager.OrderBookManager;
using Microsoft.AspNetCore.Mvc;

namespace E_Book_Store.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderBookController : ControllerBase
{
   private readonly OrderBookManager _orderBookManager;

   public OrderBookController(OrderBookManager orderBookManager)
   {
      _orderBookManager = orderBookManager;
   }
   [HttpGet]
   public IActionResult Get()
   {
      return Ok(_orderBookManager.GetAll());
   }

   [HttpPost]
   public IActionResult Post(OrderBookAddDto orderBookDto)
   {
     _orderBookManager.insert(orderBookDto);
     return Ok();
   }
}