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

        public virtual DbSet<Producer> Producers { get; set; } = null!;

        public virtual DbSet<Order> Orders { get; set; } = null!;

        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;

        public virtual DbSet<ApplicationUserStore> ApplicationUserStores { get; set; } = null!;

        public virtual DbSet<Cart> Carts { get; set; } = null!;

        public virtual DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
