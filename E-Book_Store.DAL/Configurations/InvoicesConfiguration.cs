namespace E_Book_Store.DAL.Configurations;

public class InvoicesConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(p => p.InvoicesId);
        
        //This prevents EF Core from loading soft-deleted entities by default.
        builder.HasQueryFilter(p => !p.IsDeleted);
      

        builder.HasOne(p => p.Order)
            .WithOne()
            .HasForeignKey<Invoice>(p => p.OrderId);
        
    }
}