namespace E_Book_Store.DAL.Repository.InvoicesRepository;

public interface IInvoicesRepository
{
    public IQueryable<Invoice?> GetAllInvoices();
    public Invoice? GetInvoiceById(int id);
    public void insert(Invoice invoice);
    public void Update(Invoice invoice);
    public Task Delete(Invoice invoice);
}