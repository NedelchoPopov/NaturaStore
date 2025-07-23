using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Services.Core;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Order;

namespace NaturaStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

       
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _orderService.GetOrderDetailsAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OrderCreateViewModel();
            model.Products = await GetProductSelectListAsync();
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Products = await GetProductSelectListAsync();
                return View(model);
            }

            await _orderService.CreateOrderAsync(model);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _orderService.GetOrderForDeleteAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var success = await _orderService.DeleteOrderAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        
        private async Task<IEnumerable<SelectListItem>> GetProductSelectListAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        }
    }
}
