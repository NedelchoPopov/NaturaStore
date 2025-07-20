using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .Property(o => o.CreatedOn)
                .IsRequired();

            
            builder
                .HasOne(o => o.User) 
                .WithMany() 
                .HasForeignKey(o => o.UserId) 
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            
            builder
                .Ignore(o => o.TotalPrice);

            
            builder
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder
                .HasQueryFilter(o => o.IsDeleted == false);
        }
    }
}
