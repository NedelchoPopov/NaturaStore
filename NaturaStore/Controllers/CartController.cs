// Web/Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Cart;
using NaturaStore.Data.Repository.Interfaces;
using NaturaStore.Web.ViewModels.Order;
using System.Security.Claims;

namespace NaturaStore.Web.Controllers
{
    
    public class CartController : Controller
    {
        private readonly ICartService _sessionCartService;
        private readonly IProductRepository _prodRepo;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IProductRepository prodRepo)
        {
            _sessionCartService = cartService;
            _prodRepo = prodRepo;
        }

        // GET /Cart
        [HttpGet]
        public IActionResult Index()
        {
            var vm = _sessionCartService.GetCart(HttpContext);
            return View(vm);
        }

        // POST /Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var product = await _prodRepo.GetByIdAsync(productId);
            if (product != null)
                _sessionCartService.AddToCart(HttpContext, product, quantity);
            return RedirectToAction(nameof(Index));
        }
        
        // POST /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(Guid productId, int quantity)
        {
            _sessionCartService.UpdateQuantity(HttpContext, productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        // POST /Cart/Remove
        [HttpPost]
        public IActionResult Remove(Guid productId)
        {
            _sessionCartService.RemoveFromCart(HttpContext, productId);
            return RedirectToAction(nameof(Index));
        }

        
        //[HttpPost]
        //public async Task<IActionResult> Checkout()
        //{
        //    var cart = _sessionCartService.GetCart(HttpContext);
        //    if (!cart.Items.Any())
        //    {
        //        ModelState.AddModelError("", "Your cart is empty.");
        //        return RedirectToAction(nameof(Index));
        //    }

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        //    var createModel = new OrderCreateViewModel
        //    {
        //        UserId = userId,
        //        // превръщаме всеки CartItemViewModel в OrderItemCreateViewModel
        //        Items = cart.Items.Select(i => new OrderItemCreateViewModel
        //        {
        //            ProductId = i.ProductId,
        //            Quantity = i.Quantity,
        //            Price = i.Subtotal,
        //        }).ToList()
        //    };

        //    var success = await _orderService.CreateOrderAsync(createModel);
        //    if (success)
        //    {
        //        _sessionCartService.ClearCart(HttpContext);
        //        TempData["Message"] = "Your order has been placed!";
        //        return RedirectToAction("Index", "Order");
        //    }

        //    ModelState.AddModelError("", "There was a problem placing your order.");
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
