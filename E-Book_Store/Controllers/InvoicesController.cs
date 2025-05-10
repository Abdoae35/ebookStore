using E_Book_Store.BLL.Dtos.InvoicesDto;
using E_Book_Store.BLL.Manager.InvoicesManager;

namespace E_Book_Store.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IInvoicesManager  _invoicesManager;

    public InvoicesController(IInvoicesManager invoicesManager)
    {
        _invoicesManager = invoicesManager;
    }
    [HttpGet]
    
    public IActionResult? GetAll()
    {
        var  invoices = _invoicesManager.GetAll();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var invoices = _invoicesManager.GetById(id);
        return Ok(invoices);
    }

    [HttpPost]
    public IActionResult Add(InvoicesAddDto invoicesAddDto)
    {
        _invoicesManager.insert(invoicesAddDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id ,InvoicesModifyDto invoicesModifyDto)
    {
        if (id!=invoicesModifyDto.InvoicesId)
            return BadRequest();
        _invoicesManager.Update(invoicesModifyDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var model = _invoicesManager.GetById(id);
        _invoicesManager.Delete(id);
        return Ok($"Book Is Deleted {model.OrderId}");
    }
    
    
}