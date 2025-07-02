using Microsoft.AspNetCore.Mvc;
using NaturaStore.Data;
using Microsoft.EntityFrameworkCore;

namespace NaturaStore.Web.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public class ProductController : Controller
        {
            private readonly NaturaStoreDbContext dbContext;

            public ProductController(NaturaStoreDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IActionResult> Index()
            {
                var products = await dbContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Producer)
                    .ToListAsync();

                return View(products);
            }
        }
    }
}
