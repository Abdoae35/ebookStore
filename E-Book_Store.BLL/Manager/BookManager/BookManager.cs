namespace E_Book_Store.BLL.Manager.BookManager;

public class BookManager : IBookManager
{
    private readonly IBookRepository _bookRepository;

    public BookManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public IEnumerable<BookReadDto> GetAll()
    {
        List<BookReadDto> books = _bookRepository.GetAllBooks().Select(a => new BookReadDto
        {
            Author = a.Author,
            BookUrl = a.BookUrl,
            Description = a.Description,
            Title = a.Title,
        }).ToList();
        return books;
    }

    public BookReadDto GetById(int id)
    {
        var book = _bookRepository.GetBookById(id);
        BookReadDto bookModel = new BookReadDto()
        {
            Author = book.Author,
            BookUrl = book.BookUrl,
            Description = book.Description,
            Title = book.Title
        };
        return bookModel;
    }

    public void insert(BookAddDto bookAddDto)
    {
        var book = new Book()
        {
            Author = bookAddDto.Author,
            BookUrl = bookAddDto.BookUrl,
            Description = bookAddDto.Description,
            Title = bookAddDto.Title
        };
        _bookRepository.insert(book);
    }

    public void Update(BookUpdateDto bookUpdateDto)
    {
        var book = _bookRepository.GetBookById(bookUpdateDto.BookId);
        
        book.BookUrl = bookUpdateDto.BookUrl;
        book.Description = bookUpdateDto.Description;
        book.Title = bookUpdateDto.Title;
        book.Price = bookUpdateDto.Price;
        
        _bookRepository.Update(book);
    }

    public void Delete(int id)
    {
        
      var Book = _bookRepository.GetBookById(id);
      _bookRepository.Delete(Book);
      
    }
}