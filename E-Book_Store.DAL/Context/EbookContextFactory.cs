using E_Book_Store.DAL.Context;
using Microsoft.EntityFrameworkCore.Design;


public class EbookContextFactory : IDesignTimeDbContextFactory<EbookContext>
{
    private string cs =
        "Server=localhost;Database=EbookStoreDb;User Id=sa;Password=Abdo@1234;TrustServerCertificate=True";
    public EbookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EbookContext>();
        optionsBuilder.UseSqlServer(cs);

        return new EbookContext(optionsBuilder.Options);
    }
}