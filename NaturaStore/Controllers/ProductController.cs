using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProducerService _producerService;

        public ProductController(IProductService productService, IProducerService producerService)
        {
            _productService = productService;
            _producerService = producerService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductViewModel();
            await PopulateCategoriesAndProducersAsync(model);

            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAndProducersAsync(model);
                return View(model);
            }

            await _productService.AddProductAsync(model);

            TempData["SuccessMessage"] = "Продуктът беше създаден успешно!";
            return RedirectToAction("Create");
        }

        private async Task PopulateCategoriesAndProducersAsync(CreateProductViewModel model)
        {
            var categories = await _productService.GetAllCategoriesAsync();
            var producers = await _productService.GetAllProducersAsync();

            model.Categories = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            model.Producers = producers.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
