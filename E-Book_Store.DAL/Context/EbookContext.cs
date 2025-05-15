

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
       modelBuilder.ApplyConfiguration(new CartConfigurations());
       modelBuilder.ApplyConfiguration(new WishingListConfigurattion());
       
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    entry.Entity.DeletedBy =string.Empty;
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted.Equals(true);
                    break;
            
            
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy =string.Empty;
                    break;


                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy =string.Empty;
                    break;

            }
        
           
        }
        
        return base.SaveChanges();

  
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
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<WhisingList> WhisingLists { get; set; }
    
}