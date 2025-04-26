

public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
{
    public void Configure(EntityTypeBuilder<OrderBook> builder)
    {
       builder.HasKey(ob => new { ob.OrderId, ob.BookId });
      

        builder.HasOne(ob => ob.Order)
               .WithMany(o => o.OrderBooks)
               .HasForeignKey(ob => ob.OrderId);

        builder.HasOne(ob => ob.Book)
               .WithMany(b => b.OrderBooks)
               .HasForeignKey(ob => ob.BookId);
    }

   
}