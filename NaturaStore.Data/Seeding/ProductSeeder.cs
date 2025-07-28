using NaturaStore.Data.Models;
using NaturaStore.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturaStore.Data.Seeding
{
    public static class ProductSeeder
    {
        public static async Task SeedAsync(NaturaStoreDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    // Продукти за категория "Homemade Goodies"
                    new Product
                    {
                        Name = "Български мед от Рила",
                        Description = "Натурален мед, събран от българските планини, с уникален вкус и полезни качества.",
                        Price = 12.99m,
                        CategoryId = context.Categories.First(c => c.Name == "Homemade Goodies").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Български мед").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUEABM-QGLKsFL5YzR6GEXqwm7IXEaJpgh7A&s" 
                    },

                    new Product
                    {
                        Name = "Малиново сладко",
                        Description = "Ръчно приготвено малиново сладко с аромат на зрели български малини.",
                        Price = 6.50m,
                        CategoryId = context.Categories.First(c => c.Name == "Homemade Goodies").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Натурални изкушения").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_xlGUUBrS8sqUbFkxjPQcFImLFjiApMJ-Ew&s"
                    },

                    // Продукти за категория "Herbs & Teas"
                    new Product
                    {
                        Name = "Чай от бял равнец",
                        Description = "Чай с лечебни свойства, приготвен от бял равнец, събран в планините на България.",
                        Price = 4.99m,
                        CategoryId = context.Categories.First(c => c.Name == "Herbs & Teas").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Природен свят").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpLVh1AQAdpl7tlLBgKiew5W8OwktXJvSkCg&s"
                    },
                    new Product
                    {
                        Name = "Билкова смес за чай",
                        Description = "Смес от най-добрите български билки за чаене, подходяща за успокояване и детоксикация.",
                        Price = 7.20m,
                        CategoryId = context.Categories.First(c => c.Name == "Herbs & Teas").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Природен свят").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0NEoTe9FhnYTE04jlV8Cu-NL7PqvNmcZAmA&s"
                    },

                    // Продукти за категория "Handmade Souvenirs"
                    new Product
                    {
                        Name = "Ръчно изработена чаша",
                        Description = "Уникално изработена керамична чаша с ръчно рисуван български мотив.",
                        Price = 15.00m,
                        CategoryId = context.Categories.First(c => c.Name == "Handmade Souvenirs").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Ръчно изработени сувенири").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSj41tH2Oawh33blu7wCgGtOyMw1M0jK7mfWA&s"
                    },
                    new Product
                    {
                        Name = "Тениска с български мотив",
                        Description = "Ръчно изработена тениска с уникален български етно дизайн.",
                        Price = 18.50m,
                        CategoryId = context.Categories.First(c => c.Name == "Handmade Souvenirs").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Ръчно изработени сувенири").Id,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbmtLay20cT2kneP0UGl4qjfrc66TWaKATzQ&s"
                    }
                };

                await context.Products.AddRangeAsync(products);  
                await context.SaveChangesAsync();
            }
        }
    }
}
