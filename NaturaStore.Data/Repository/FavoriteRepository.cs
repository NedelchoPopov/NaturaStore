using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Data.Models;
using NaturaStore.Data.Repository.Interfaces;

namespace NaturaStore.Data.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly NaturaStoreDbContext _ctx;
        public FavoriteRepository(NaturaStoreDbContext ctx) => _ctx = ctx;

        public async Task<ApplicationUserStore?> GetAsync(string userId, Guid productId)
            => await _ctx.ApplicationUserStores
                         .SingleOrDefaultAsync(f => f.ApplicationUserId == userId && f.ProductId == productId);

        public async Task<bool> ExistsAsync(string userId, Guid productId)
            => await _ctx.ApplicationUserStores
                          .AnyAsync(f => f.ApplicationUserId == userId && f.ProductId == productId);

        public async Task AddAsync(ApplicationUserStore fav)
        {
            _ctx.ApplicationUserStores.Add(fav);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> RemoveAsync(ApplicationUserStore fav)
        {
            _ctx.ApplicationUserStores.Remove(fav);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ApplicationUserStore>> GetAllByUserAsync(string userId)
            => await _ctx.ApplicationUserStores
                         .Include(f => f.Product)
                         .Where(f => f.ApplicationUserId == userId && !f.IsDeleted)
                         .ToListAsync();
    }
}
