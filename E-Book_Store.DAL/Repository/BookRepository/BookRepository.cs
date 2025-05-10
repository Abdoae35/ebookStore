using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly EbookContext _context;

    public BookRepository(EbookContext context)
    {
        _context = context;
    }
    
    public ICollection<Book> GetAllBooks()
    {
        var books = _context.Books.AsNoTracking().ToList();
        return books;
        
    }

    public Book? GetBookById(int id)
    {
        var book = _context.Books.Find(id);
        return book ?? null;
    }

    public void insert(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Update(Book book)
    {
        
       //_context.Books.Update(book);
       _context.SaveChanges();
       
    }

    public void Delete(Book book)
    {
       _context.Books.Remove(book);
       _context.SaveChanges();
    }
}