

namespace E_Book_Store.DAL.Context;

public class EbookContext : DbContext
{
    public EbookContext(DbContextOptions<EbookContext> options)  : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
       modelBuilder.ApplyConfiguration(new OrderConfiguration());
       modelBuilder.ApplyConfiguration(new BookConfiguration());
       modelBuilder.ApplyConfiguration(new ReviewAndRatingConfiguration());
       modelBuilder.ApplyConfiguration(new PaymentConfiguration());
       modelBuilder.ApplyConfiguration(new UserConfiguration());
       

       
    }

    // ADD Dbset here 
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ReviewAndRating> ReviewsAndRatings { get; set; }
    //public DbSet<WhisingList> WhisingLists { get; set; }
    
}