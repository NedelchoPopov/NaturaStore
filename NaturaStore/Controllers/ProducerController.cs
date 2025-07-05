using Microsoft.AspNetCore.Mvc;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Producer;

namespace NaturaStore.Web.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateNewProducerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProducerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _producerService.CreateProducerAsync(model);
            TempData["SuccessMessage"] = $"Производителят \"{model.Name}\" беше създаден успешно.";
            return RedirectToAction("Create", "Product");
        }

    }
}
