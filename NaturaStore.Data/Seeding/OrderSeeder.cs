using NaturaStore.Data.Models;
using NaturaStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class OrderSeeder
{
    public async Task SeedAsync(NaturaStoreDbContext context)
    {
        // Проверяваме дали категорията "Electronics" съществува
        var category = context.Categories.FirstOrDefault(c => c.Name == "Electronics");

        if (category == null)
        {
            // Ако не съществува, добавяме категорията
            category = new Category
            {
                Name = "Electronics",
                Description = "All kinds of electronic products."
            };
            context.Categories.Add(category);
            await context.SaveChangesAsync(); // Записваме категорията в базата
        }

        // Проверяваме дали производителят съществува
        var producer = context.Producers.FirstOrDefault(p => p.Name == "TechCorp");

        if (producer == null)
        {
            // Ако не съществува, добавяме нов производител
            producer = new Producer
            {
                Id = Guid.NewGuid(), // Създаваме нов GUID за производителя
                Name = "TechCorp",
                Description = "A leading producer of electronic devices.",
                Location = "USA",
                ContactEmail = "contact@techcorp.com",
                PhoneNumber = "+1234567890",
                IsDeleted = false
            };
            context.Producers.Add(producer);
            await context.SaveChangesAsync(); // Записваме производителя в базата
        }

        // Сега добавяме продуктите
        var product1 = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Laptop",
            Description = "A high-performance laptop.",
            Price = 1000.00m,
            CreatedOn = DateTime.UtcNow,
            CategoryId = category.Id, // Използваме ID-то на категорията
            ProducerId = producer.Id, // Използваме ID-то на производителя
            IsDeleted = false
        };

        var product2 = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smartphone",
            Description = "A latest model smartphone.",
            Price = 500.00m,
            CreatedOn = DateTime.UtcNow,
            CategoryId = category.Id, // Използваме ID-то на категорията
            ProducerId = producer.Id, // Използваме ID-то на производителя
            IsDeleted = false
        };

        // Добавяме продуктите
        context.Products.AddRange(product1, product2);
        await context.SaveChangesAsync(); // Записваме продуктите в базата
    }
}
