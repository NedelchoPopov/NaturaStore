using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var producers = await _producerService.GetAllProducersAsync();

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
        //public async Task<IActionResult> Index()
        //{
        //    var products = await _productService.GetAllProductsAsync();
        //    return View(products);
        //}

        public async Task<IActionResult> Index(string? searchTerm, int page = 1, int pageSize = 10)
        {
            var query = _productService.QueryAll();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm));
            }

            var totalItems = await query.CountAsync();
            var products = await query
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var vm = new ProductListViewModel
            {
                Items = products.Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Producer = p.Producer.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }),
                PageNumber = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                SearchTerm = searchTerm
            };

            return View(vm);
        }


        public async Task<IActionResult> Details(Guid id) 
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Edit(Guid id)  // Променено от int на Guid
        {
            var viewModel = await _productService.GetProductForEditAsync(id);
            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _productService.GetCategoriesAsync();
                model.Producers = await _producerService.GetProducersAsync();
                return View(model);
            }

            var success = await _productService.UpdateAsync(model);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)  // Променено от int на Guid
        {
            var product = await _productService.GetProductForDeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)  
        {
            bool isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
