
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Configurations
{
    public class ApplicationUserStoreConfiguration : IEntityTypeConfiguration<ApplicationUserStore>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserStore> builder)
        {
            // Composite key = favorites
            builder.HasKey(aus => new { aus.ApplicationUserId, aus.ProductId });

            builder.Property(aus => aus.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasQueryFilter(f => !f.IsDeleted);

            // Favorite → AspNetUsers
            builder.HasOne(aus => aus.ApplicationUser)
                   .WithMany()
                   .HasForeignKey(aus => aus.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Favorite → Products
            builder.HasOne(aus => aus.Product)
                   .WithMany(p => p.UserFavoriteProducts)
                   .HasForeignKey(aus => aus.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
