using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IEnumerable<SelectListItem>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllProducersAsync()
        {
            return await _dbContext.Producers
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();
        }

        public async Task AddProductAsync(CreateProductViewModel inputModel)
        {
            if (!string.IsNullOrWhiteSpace(inputModel.NewProducerName))
            {
                var newProducer = new Producer
                {
                    Name = inputModel.NewProducerName
                };

                await _dbContext.Producers.AddAsync(newProducer);
                await _dbContext.SaveChangesAsync();

                inputModel.ProducerId = newProducer.Id;
            }


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
