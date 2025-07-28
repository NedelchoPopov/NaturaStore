using System;
using System.Threading.Tasks;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<ApplicationUserStore?> GetAsync(string userId, Guid productId);
        Task<bool> ExistsAsync(string userId, Guid productId);
        Task AddAsync(ApplicationUserStore fav);
        Task<bool> RemoveAsync(ApplicationUserStore fav);
        Task<IEnumerable<ApplicationUserStore>> GetAllByUserAsync(string userId);
    }
}
