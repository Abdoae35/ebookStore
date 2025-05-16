using E_Book_Store.BLL.Dtos.InvoicesDto;

namespace E_Book_Store.BLL.Manager.InvoicesManager;

public interface IInvoicesManager
{
    public IEnumerable<InvoicesReadDto> GetAll();
    public InvoicesReadDto GetById(int id);
    public void insert(InvoicesAddDto invoicesAddDto);
    public void Update(InvoicesModifyDto invoicesModifyDto);
    public void Delete(int id);
}