using E_Book_Store.BLL.Dtos.BookDtos;
using E_Book_Store.BLL.Dtos.PaginationList;
using E_Book_Store.BLL.Manager.BookManager;

namespace E_Book_Store.Controllers;




[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookManager _bookManager;

    public BookController(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }
        //I will apply pagination here over this api
        // first Download two packages cloudScribe.Pagination.Models & cloudScribe.web.Pagination
    [HttpGet]
    public IActionResult GetAll(int page = 1, int pageSize = 6)
    {
        var books = _bookManager.GetAll(page, pageSize);
        return Ok(books);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Book = _bookManager.GetById(id);
        return Book == null ? NotFound("Book Is Not Available") : Ok(Book);
    }

    [HttpPost]
    public IActionResult Add(BookAddDto  bookAddDto)
    {
        _bookManager.insert(bookAddDto);
        //createdataction
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id,BookUpdateDto bookUpdateDto)
    {
        if (id!=bookUpdateDto.BookId)
            return BadRequest();
        
        var book = _bookManager.GetById(bookUpdateDto.BookId);
        
        if (book == null) 
            return NotFound("Book Is Not Available");
        
        _bookManager.Update(bookUpdateDto);
        
        return Ok($"Book Is Updated {bookUpdateDto.Title}");
        
        
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _bookManager.GetById(id);
        _bookManager.Delete(id);
        return Ok($"Book Is Deleted {book.Title}");
    }
    
    
}