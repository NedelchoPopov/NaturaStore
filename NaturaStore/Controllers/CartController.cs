// Web/Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Cart;
using NaturaStore.Data.Repository.Interfaces;

namespace NaturaStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _prodRepo;

        public CartController(ICartService cartService, IProductRepository prodRepo)
        {
            _cartService = cartService;
            _prodRepo = prodRepo;
        }

        // GET /Cart
        [HttpGet]
        public IActionResult Index()
        {
            var vm = _cartService.GetCart(HttpContext);
            return View(vm);
        }

        // POST /Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var product = await _prodRepo.GetByIdAsync(productId);
            if (product != null)
                _cartService.AddToCart(HttpContext, product, quantity);
            return RedirectToAction(nameof(Index));
        }

        // POST /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(Guid productId, int quantity)
        {
            _cartService.UpdateQuantity(HttpContext, productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        // POST /Cart/Remove
        [HttpPost]
        public IActionResult Remove(Guid productId)
        {
            _cartService.RemoveFromCart(HttpContext, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
