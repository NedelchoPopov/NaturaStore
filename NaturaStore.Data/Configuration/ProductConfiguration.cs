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
    using static GCommon.ApplicationConstants;

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
                .HasDefaultValueSql(DateCreatedSqlType);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder
                    .HasOne(p => p.Producer)
                    .WithMany(pr => pr.Products)      
                    .HasForeignKey(p => p.ProducerId) 
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);


            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            
            builder
                .HasQueryFilter(p => p.IsDeleted == false);

        }
    }
}
