public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.OrderId);
        builder.Property(o => o.Date).HasDefaultValueSql("GETDATE()");
        builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
        builder.Property(o => o.State).HasMaxLength(50).IsRequired();

        builder.HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId);
    }
}