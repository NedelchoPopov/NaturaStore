using NaturaStore.Data.Models;
using NaturaStore.Data.Repository.Interfaces;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favRepo;
        private readonly IProductService _prodService;

        public FavoriteService(IFavoriteRepository favRepo, IProductService prodService)
        {
            _favRepo = favRepo;
            _prodService = prodService;
        }

        public async Task<IEnumerable<ProductListViewModel>> GetFavoritesAsync(string userId)
        {
            var favs = await _favRepo.GetAllByUserAsync(userId);
            
            return favs.Select(f => new ProductListViewModel
            {
                Id = f.ProductId,
                Name = f.Product.Name,
                Price = f.Product.Price,
                ImageUrl = f.Product.ImageUrl
            });
        }

        public async Task<bool> AddToFavoritesAsync(string userId, Guid productId)
        {
            if (await _favRepo.ExistsAsync(userId, productId))
                return false;

            var fav = new ApplicationUserStore
            {
                ApplicationUserId = userId,
                ProductId = productId,
                IsDeleted = false
            };
            await _favRepo.AddAsync(fav);
            return true;
        }

        public async Task<bool> RemoveFromFavoritesAsync(string userId, Guid productId)
        {
            var fav = await _favRepo.GetAsync(userId, productId);
            if (fav == null)
                return false;
            return await _favRepo.RemoveAsync(fav);
        }
    }
}
