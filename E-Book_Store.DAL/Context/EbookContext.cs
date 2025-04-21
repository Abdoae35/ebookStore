using Microsoft.EntityFrameworkCore;

namespace E_Book_Store.DAL.Context;

public class EbookContext : DbContext
{
    public EbookContext(DbContextOptions<EbookContext> options)  : base(options)
    {
        
    }
    // ADD Dbset here 
}