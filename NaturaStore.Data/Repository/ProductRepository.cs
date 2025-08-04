

namespace NaturaStore.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using NaturaStore.Data;
    using NaturaStore.Data.Models;
    using NaturaStore.Data.Repository;
    using NaturaStore.Data.Repository.Interfaces;

    public class ProductRepository : BaseRepository<Product, Guid> , IProductRepository
    {
        public ProductRepository(NaturaStoreDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Product> AllAsQueryable()
            => this.DbContext.Products
                     .AsNoTracking()
                     .Include(p => p.Category)
                     .Include(p => p.Producer);
    }
}
    

