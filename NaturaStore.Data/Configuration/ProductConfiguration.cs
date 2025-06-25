using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Configuration
{
    using static NaturaStore.Data.Common.EntityConstants.Product;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLenght);

            builder
                .Property(p => p.Description)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(PricePrecision, PriceScale)
                .IsRequired();

            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
