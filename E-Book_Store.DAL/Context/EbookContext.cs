using E_Book_Store.DAL.Models;

namespace E_Book_Store.DAL.Context;

public class EbookContext : DbContext
{
    public EbookContext(DbContextOptions<EbookContext> options)  : base(options)
    {
        
    }
    // ADD Dbset here 
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ReviewAndRating> ReviewsAndRatings { get; set; }
    public DbSet<WhisingList> WhisingLists { get; set; }
    
}