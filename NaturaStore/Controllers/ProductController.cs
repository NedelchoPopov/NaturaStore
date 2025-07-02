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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductViewModel();
            await PopulateCategoriesAndProducersAsync(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ProducerId == 0 || model.ProducerId.ToString() == "none" ||
                   (model.NewProducer != null && !string.IsNullOrWhiteSpace(model.NewProducer.Name)))
                {
                    model.ProducerId = 0;
                }

                await PopulateCategoriesAndProducersAsync(model);
                return View(model);
            }

            await _productService.AddProductAsync(model);

            TempData["Success"] = "Продуктът беше създаден успешно!";
            return RedirectToAction("Create");
        }

        // 👇 Тук изнесохме логиката за пълнене на DropDown-ите
        private async Task PopulateCategoriesAndProducersAsync(CreateProductViewModel model)
        {
            var categories = await _productService.GetAllCategoriesAsync();
            var producers = await _productService.GetAllProducersAsync();

            model.Categories = categories
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            model.Producers = producers
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToList();
        }
    }
}
