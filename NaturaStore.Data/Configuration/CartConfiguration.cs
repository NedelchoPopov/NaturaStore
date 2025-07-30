//// Data/Configurations/CartConfiguration.cs
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using NaturaStore.Data.Models;

//namespace NaturaStore.Data.Configurations
//{
//    public class CartConfiguration : IEntityTypeConfiguration<Cart>
//    {
//        public void Configure(EntityTypeBuilder<Cart> builder)
//        {
//            builder.HasKey(c => c.Id);

//            builder.Property(c => c.UserId)
//               .IsRequired();

//            // Връзка Cart → AspNetUsers
//            builder.HasOne<IdentityUser>()
//                   .WithMany()
//                   .HasForeignKey(c => c.UserId)
//                   .OnDelete(DeleteBehavior.Cascade);

//            // Cart → CartItems
//            builder.HasMany(c => c.Items)
//                   .WithOne(ci => ci.Cart)
//                   .HasForeignKey(ci => ci.CartId)
//                   .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}
