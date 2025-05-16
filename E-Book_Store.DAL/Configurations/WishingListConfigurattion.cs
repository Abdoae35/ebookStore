

namespace E_Book_Store.DAL.Configurations;

public class WishingListConfigurattion :IEntityTypeConfiguration<WhisingList>
{
   public void Configure(EntityTypeBuilder<WhisingList> builder)
   {
       builder.HasKey(a => a.WishId);

       builder.HasMany(a => a.Books)
           .WithOne(b => b.WhisingList)
           .HasForeignKey(a => a.WhishingId);
   }
}