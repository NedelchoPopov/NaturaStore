using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Configuration
{
    public class ApplicationUserStoreConfiguration : IEntityTypeConfiguration<ApplicationUserStore>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserStore> builder)
        {
            builder.HasKey(aus => aus.ApplicationUserId);

            builder.Property(aus => aus.ApplicationUserId)
                   .IsRequired();

            builder.Property(aus => aus.IsDeleted)
                   .HasDefaultValue(false);

            
            builder.HasOne(aus => aus.ApplicationUser)
                   .WithMany()  
                   .HasForeignKey(aus => aus.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(aus => aus.Product)
                   .WithMany(p => p.UserFavoriteProducts)  
                   .HasForeignKey(aus => aus.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasQueryFilter(aus => aus.IsDeleted == false);
        }
    }
}
