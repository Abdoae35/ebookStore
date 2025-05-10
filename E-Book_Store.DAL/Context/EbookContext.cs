

using E_Book_Store.DAL.Configurations;
using E_Book_Store.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_Book_Store.DAL.Context;

public class EbookContext : IdentityDbContext<ApplicationUser>
{
    public EbookContext(DbContextOptions<EbookContext> options)  : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
       modelBuilder.ApplyConfiguration(new OrderConfiguration());
       modelBuilder.ApplyConfiguration(new BookConfiguration());
       modelBuilder.ApplyConfiguration(new ReviewAndRatingConfiguration());
       modelBuilder.ApplyConfiguration(new InvoicesConfiguration());
       modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Deleted && e.Entity is Invoice))
        {
            entry.State = EntityState.Modified;
            ((Invoice)entry.Entity).IsDeleted = true;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    // ADD Dbset here 
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }
    
    public DbSet<Invoice?> Invoices { get; set; }
    public DbSet<ReviewAndRating> ReviewsAndRatings { get; set; }

    //public DbSet<WhisingList> WhisingLists { get; set; }
    
}