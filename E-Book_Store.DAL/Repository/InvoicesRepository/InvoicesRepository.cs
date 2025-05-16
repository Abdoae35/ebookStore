using E_Book_Store.DAL.Context;

namespace E_Book_Store.DAL.Repository.InvoicesRepository;

public class InvoicesRepository : IInvoicesRepository
{
    private readonly EbookContext _context;

    public InvoicesRepository(EbookContext context)
    {
        _context = context;
    }
    
    
    public IQueryable<Invoice?> GetAllInvoices()
    {
        return _context.Invoices;
    }

    public Invoice? GetInvoiceById(int id)
    {
        return _context.Invoices.Find(id);
    }

    public void insert(Invoice invoice)
    {
       _context.Invoices.Add(invoice);
       _context.SaveChanges();
    }

    public void Update(Invoice invoice)
    {
        var model = _context.Update(invoice);
        _context.SaveChanges();
    }

    public async Task Delete(Invoice invoice)
    {
       _context.Invoices.Remove(invoice);
      await _context.SaveChangesAsync();
    }
}