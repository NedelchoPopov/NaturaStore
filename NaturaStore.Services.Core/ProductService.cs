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

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllProducersAsync()
        {
            return await _dbContext.Producers.ToListAsync();
        }

        public async Task AddProductAsync(CreateProductViewModel inputModel)
        {
            // Ако потребителят е въвел нов производител - създаваме го
            if (inputModel.NewProducer != null && !string.IsNullOrWhiteSpace(inputModel.NewProducer.Name))
            {
                var newProducer = new Producer
                {
                    Name = inputModel.NewProducer.Name,
                    Description = inputModel.NewProducer.Description,
                    Location = inputModel.NewProducer.Location,
                    ContactEmail = inputModel.NewProducer.ContactEmail,
                    PhoneNumber = inputModel.NewProducer.PhoneNumber
                };

                await _dbContext.Producers.AddAsync(newProducer);
                await _dbContext.SaveChangesAsync();

                inputModel.ProducerId = newProducer.Id;
            }

            // Валидация: дали категорията съществува
            bool categoryExists = await _dbContext.Categories
                .AnyAsync(c => c.Id == inputModel.CategoryId);

            if (!categoryExists)
            {
                throw new ArgumentException("Invalid Category ID.");
            }

            // Валидация: дали производителят съществува
            bool producerExists = await _dbContext.Producers
                .AnyAsync(p => p.Id == inputModel.ProducerId);

            if (!producerExists)
            {
                throw new ArgumentException("Invalid Producer ID.");
            }

            // Създаваме продукта
            var product = new Product
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
