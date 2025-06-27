using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturaStore.Data.Common;
using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Configuration
{
    using static EntityConstants.Producer;

    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(p => p.Description)
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(p => p.Location)
                .HasMaxLength(LocationMaxLength);

            builder
                .Property(p => p.ContactEmail)
                .HasMaxLength(ContactEmailMaxLength);

            builder
                .Property(p => p.PhoneNumber)
                .HasMaxLength(PhoneNumberMaxLength);
        }
    }
}
