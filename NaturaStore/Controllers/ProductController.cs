using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly NaturaStoreDbContext _dbContext;

        public ProductController(IProductService productService,NaturaStoreDbContext dbContext)
        {
            _productService = productService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var model = new CreateProductViewModel
            {
                Categories = await _productService.GetAllCategoriesAsync(),
                Producers = await _productService.GetAllProducersAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                model.Categories = await _productService.GetAllCategoriesAsync();
                model.Producers = await _productService.GetAllProducersAsync();
                return View(model);
            }

            await _productService.AddProductAsync(model);

            TempData["Success"] = "Продуктът беше създаден успешно!";
            return RedirectToAction("Create");
        }
    }
}
