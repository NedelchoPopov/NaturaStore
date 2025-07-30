using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Common.Enums;
using NaturaStore.Services.Core;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Cart;
using NaturaStore.Web.ViewModels.Order;
using System.Security.Claims;

namespace NaturaStore.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly SessionCartService _sessionCartService;

        public OrdersController(
            IOrderService orderService,
            SessionCartService sessionCartService)
        {
            _orderService = orderService;
            _sessionCartService = sessionCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var orders = await _orderService.GetUserOrdersAsync(userId);
            return View(orders);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var vm = await _orderService.GetOrderDetailsAsync(id);
            if (vm == null) return NotFound();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            // Вземаме текущата "кошница" от сесията
            CartViewModel cart = _sessionCartService.GetCart(HttpContext);

            if (!cart.Items.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            // Подготвяме viewmodel
            var vm = new CheckoutViewModel
            {
                Items = cart.Items,
                GrandTotal = cart.GrandTotal   // или cart.Total, както си го кръстил
            };

            return View(vm);
        }


        // POST: /Orders/Checkout
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // 1) Вземаме cart от сесия:
            CartViewModel cart = _sessionCartService.GetCart(HttpContext);

            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return RedirectToAction("Index", "Cart");
            }

            // 2) Преобразуваме към OrderCreateViewModel
            var createModel = new OrderCreateViewModel
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                Items = cart.Items.Select(ci => new OrderItemCreateViewModel
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            // 3) Създаваме поръчка
            bool success = await _orderService.CreateOrderAsync(createModel);

            if (success)
            {
                // 4) Изчистваме cart-а от сесия
                _sessionCartService.ClearCart(HttpContext);

                TempData["Message"] = "Your order has been placed!";
                return RedirectToAction("Index", "Orders");
            }

            ModelState.AddModelError("", "There was a problem placing your order.");
            return RedirectToAction("Index", "Cart");
        }

    }
}
