using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            bool categoryExists = await _dbContext.Categories
            .AnyAsync(c => c.Id == inputModel.CategoryId);

            if (!categoryExists)
            {
                throw new ArgumentException("Invalid Category ID.");
            }

            
            bool producerExists = await _dbContext.Producers
                .AnyAsync(p => p.Id == inputModel.ProducerId);

            if (!producerExists)
            {
                throw new ArgumentException("Invalid Producer ID.");
            }
            Product product = new Product
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Price = inputModel.Price,
                ImageUrl = inputModel.ImageUrl,
                CategoryId = inputModel.CategoryId,
                ProducerId = inputModel.ProducerId,
                CreatedOn = DateTime.UtcNow
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}
