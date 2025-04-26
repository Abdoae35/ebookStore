public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Phone).HasMaxLength(15);
        builder.Property(u => u.Address).HasMaxLength(250);
    }
}