using Microsoft.AspNetCore.Mvc;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Cart;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NaturaStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
            => _cartService = cartService;

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            // взимаме userId (можеш да ползваш ClaimTypes.NameIdentifier ако не ползваш UserName за ID)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _cartService.GetCartAsync(userId);
            return View(model);
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ok = await _cartService.AddToCartAsync(userId, productId);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/RemoveFromCart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ok = await _cartService.RemoveFromCartAsync(userId, productId);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
