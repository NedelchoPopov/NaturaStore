using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Producer;
using NaturaStore.Web.ViewModels.Product;
using NaturaStore.Web.Helpers;
using NaturaStore.GCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Services.Core
{
    public class ProductService : IProductService , IProducerService
    {
        private readonly NaturaStoreDbContext _dbContext;

        public ProductService(NaturaStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllProducersAsync()
        {
            return await _dbContext.Producers.ToListAsync();
        }

        public async Task<bool> ProducerExistsAsync(int producerId)
        {
            return await _dbContext.Producers.AnyAsync(p => p.Id == producerId);
        }

        public async Task<int> CreateProducerAsync(CreateNewProducerViewModel newProducer)
        {
            var producer = new Producer
            {
                Name = newProducer.Name,
                Description = newProducer.Description,
                Location = newProducer.Location,
                ContactEmail = newProducer.ContactEmail,
                PhoneNumber = newProducer.PhoneNumber,
            };

            _dbContext.Producers.Add(producer);
            await _dbContext.SaveChangesAsync();

            return producer.Id;
        }

        public async Task AddProductAsync(CreateProductViewModel inputModel)
        {
            if (inputModel.ProducerId == 0)
            {
                throw new ArgumentException("Producer must be selected or a new one must be provided.");
            }

            bool categoryExists = await _dbContext.Categories.AnyAsync(c => c.Id == inputModel.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("Invalid Category ID.");
            }

            bool producerExists = await _dbContext.Producers.AnyAsync(p => p.Id == inputModel.ProducerId);
            if (!producerExists)
            {
                throw new ArgumentException("Invalid Producer ID.");
            }

            var product = new Product
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





    }
}
