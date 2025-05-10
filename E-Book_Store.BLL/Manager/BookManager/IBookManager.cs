namespace E_Book_Store.BLL.Manager.BookManager;

public interface IBookManager
{
    public IEnumerable<BookReadDto> GetAll();
    public BookReadDto GetById(int id);
    public void insert(BookAddDto bookAddDto);
    public void Update(BookUpdateDto bookUpdateDto);
    public void Delete(int id);
}