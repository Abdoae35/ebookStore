

public class ReviewAndRatingConfiguration : IEntityTypeConfiguration<ReviewAndRating>
{
    public void Configure(EntityTypeBuilder<ReviewAndRating> builder)
    {
        builder.HasKey(r => r.RateId);
        builder.Property(r => r.NumStar).IsRequired();
        builder.Property(r => r.Description).HasMaxLength(500);

        builder.HasOne(r => r.Book)
               .WithMany(b => b.Reviews)
               .HasForeignKey(r => r.BookId);

        builder.HasOne(r => r.User)
               .WithMany(u => u.Reviews)
               .HasForeignKey(r => r.UserId);
    }


}