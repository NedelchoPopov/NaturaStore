using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaturaStore.Data.Models;
using System.Reflection;

namespace NaturaStore.Data
{
    public class NaturaStoreDbContext : IdentityDbContext
    {
        public NaturaStoreDbContext(DbContextOptions<NaturaStoreDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
