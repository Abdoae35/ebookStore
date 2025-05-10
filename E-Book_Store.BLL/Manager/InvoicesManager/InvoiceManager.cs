using E_Book_Store.BLL.Dtos.InvoicesDto;
using E_Book_Store.DAL.Repository.InvoicesRepository;

namespace E_Book_Store.BLL.Manager.InvoicesManager;

public class InvoiceManager  : IInvoicesManager
{
    
    private readonly IInvoicesRepository  _invoicesRepository;

    public InvoiceManager(IInvoicesRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }
    
    
    public IEnumerable<InvoicesReadDto> GetAll()
    {
       var models = _invoicesRepository.GetAllInvoices().Select(a=>new InvoicesReadDto
        {
            State = a.State,
            UserId = a.UserId,
            OrderId = a.OrderId,
        }).ToList();
        return models;
    }

    public InvoicesReadDto GetById(int id)
    {
        var model = _invoicesRepository.GetInvoiceById(id);
        InvoicesReadDto modelDto = new InvoicesReadDto()
        {
            State = model.State,
            UserId = model.UserId,
            OrderId = model.OrderId,
        };
        return modelDto;
    }

    public void insert(InvoicesAddDto invoicesAddDto)
    {
        Invoice invoice = new Invoice();
        invoice.State = invoicesAddDto.State;
        invoice.UserId = invoicesAddDto.UserId;
        invoice.OrderId = invoicesAddDto.OrderId;
        
       _invoicesRepository.insert(invoice);
        

    }

    public void Update(InvoicesModifyDto invoicesModifyDto)
    {
        var modelfromDb = _invoicesRepository.GetInvoiceById(invoicesModifyDto.InvoicesId) ??
                          throw new ArgumentNullException("_invoicesRepository.GetInvoiceById(invoicesModifyDto.InvoicesId)");
        
        modelfromDb.State = invoicesModifyDto.State;
        modelfromDb.UserId = invoicesModifyDto.UserId;
        modelfromDb.OrderId = invoicesModifyDto.OrderId;
        
    }

    public void Delete(int id)
    {
        var deleteModel = _invoicesRepository.GetInvoiceById(id);
        
        if (deleteModel != null)
            _invoicesRepository.Delete(deleteModel);
    }
}