using Microsoft.AspNetCore.Mvc;
using NaturaStore.Services.Core;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Favorite;
using NaturaStore.Web.ViewModels.Product;
using System.Security.Claims;

namespace NaturaStore.Web.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _favService;
        public FavoritesController(IFavoriteService favService)
            => _favService = favService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var products = await _favService.GetFavoritesAsync(userId);

            var vm = new FavoriteListViewModel
            {
                Items = products.Select(p => new FavoriteItemViewModel
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToList()
            };

            return View(vm);
        }

        [HttpPost]                     
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _favService.AddToFavoritesAsync(userId, productId);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _favService.RemoveFromFavoritesAsync(userId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
