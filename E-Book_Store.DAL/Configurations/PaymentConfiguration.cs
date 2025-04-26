public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.PaymentId);
        builder.Property(p => p.Type).HasMaxLength(20).IsRequired();
        builder.Property(p => p.CVV).HasMaxLength(4).IsRequired();
        builder.Property(p => p.Expiration).IsRequired();

        builder.HasOne(p => p.Order)
               .WithOne()
               .HasForeignKey<Payment>(p => p.OrderId);
    }
}