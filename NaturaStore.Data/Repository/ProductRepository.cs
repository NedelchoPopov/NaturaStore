

namespace NaturaStore.Data.Repository
{
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
    }
}
