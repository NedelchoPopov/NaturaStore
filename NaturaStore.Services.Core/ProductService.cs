using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.Helpers;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core
{
    public class ProductService : IProductService
    {
        private readonly NaturaStoreDbContext _dbContext;

        public ProductService(NaturaStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(CreateProductViewModel inputModel)
        {
            var product = new Data.Models.Product
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Price = inputModel.Price,
                ImageUrl = ImageHelper.GetValidImageUrl(inputModel.ImageUrl),
                CategoryId = inputModel.CategoryId,
                ProducerId = inputModel.ProducerId,
                CreatedOn = DateTime.UtcNow
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync()
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Producer = p.Producer.Name,
                    Price = p.Price,
                    ImageUrl = ImageHelper.GetValidImageUrl(p.ImageUrl)
                })
                .ToListAsync();
        }

        public async Task<ProductDetailsViewModel?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = ImageHelper.GetValidImageUrl(p.ImageUrl),
                    Category = p.Category.Name,
                    Producer = p.Producer.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EditProductViewModel?> GetProductForEditAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;

            var categories = await GetCategoriesAsync();
            var producers = await GetProducersAsync();

            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ProducerId = product.ProducerId,
                ImageUrl = product.ImageUrl,
                Categories = categories,
                Producers = producers
            };
        }

        public async Task<bool> UpdateAsync(EditProductViewModel model)
        {
            var product = await _dbContext.Products.FindAsync(model.Id);
            if (product == null) return false;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.ProducerId = model.ProducerId;
            product.ImageUrl = model.ImageUrl;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            return await _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetProducersAsync()
        {
            return await _dbContext.Producers
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
