namespace E_Book_Store.DAL.Configurations;

public class CartConfigurations : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
       builder.HasKey(x => x.Id);
     
      
    }
}