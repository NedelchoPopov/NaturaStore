using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<ProductItemViewModel>> GetFavoritesAsync(string userId);
        Task<bool> AddToFavoritesAsync(string userId, Guid productId);
        Task<bool> RemoveFromFavoritesAsync(string userId, Guid productId);
    }
}
