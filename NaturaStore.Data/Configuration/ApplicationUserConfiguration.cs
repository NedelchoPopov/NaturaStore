using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUserStore>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserStore> builder)
        {
            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.Address)
                .HasMaxLength(250);
        }
    }
}
