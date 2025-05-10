namespace E_Book_Store.DAL.Repository.BookRepository;

public interface IBookRepository
{
    //IQeuerable
    public ICollection<Book> GetAllBooks();
    public Book GetBookById(int id);
    public void insert(Book book);
    public void Update(Book book);
    public void Delete(Book book);
}