//
//
// namespace E_Book_Store.DAL.Configurations;
//
// public class WishingListConfigurattion :IEntityTypeConfiguration<WhisingList>
// {
//    public void Configure(EntityTypeBuilder<WhisingList> builder)
//    {
//         // builder.HasOne(wl => wl.User)
//         //     .WithOne(u => u.WishingList)
//         //     .HasForeignKey<WishingList>(wl => wl.UserId)
//         //     .OnDelete(DeleteBehavior.Cascade);
//         //
//         // builder.HasMany>(wl => wl.Books)
//         //     .WithMany(b => b.WishingLists)
//         //     .UsingEntity(j => j.ToTable("WishingListBook"));
//     }
// }