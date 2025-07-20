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
            if (!context.Products.Any())  // Проверка дали има вече продукти в базата
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
                        ImageUrl = "images/products/bulgaria_honey.jpg"
                    },
                    new Product
                    {
                        Name = "Малиново сладко",
                        Description = "Ръчно приготвено малиново сладко с аромат на зрели български малини.",
                        Price = 6.50m,
                        CategoryId = context.Categories.First(c => c.Name == "Homemade Goodies").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Натурални изкушения").Id,
                        ImageUrl = "images/products/raspberry_jam.jpg"
                    },

                    // Продукти за категория "Herbs & Teas"
                    new Product
                    {
                        Name = "Чай от бял равнец",
                        Description = "Чай с лечебни свойства, приготвен от бял равнец, събран в планините на България.",
                        Price = 4.99m,
                        CategoryId = context.Categories.First(c => c.Name == "Herbs & Teas").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Природен свят").Id,
                        ImageUrl = "images/products/yarrow_tea.jpg"
                    },
                    new Product
                    {
                        Name = "Билкова смес за чай",
                        Description = "Смес от най-добрите български билки за чаене, подходяща за успокояване и детоксикация.",
                        Price = 7.20m,
                        CategoryId = context.Categories.First(c => c.Name == "Herbs & Teas").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Природен свят").Id,
                        ImageUrl = "images/products/herbal_tea_mix.jpg"
                    },

                    // Продукти за категория "Handmade Souvenirs"
                    new Product
                    {
                        Name = "Ръчно изработена чаша",
                        Description = "Уникално изработена керамична чаша с ръчно рисуван български мотив.",
                        Price = 15.00m,
                        CategoryId = context.Categories.First(c => c.Name == "Handmade Souvenirs").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Ръчно изработени сувенири").Id,
                        ImageUrl = "images/products/handmade_cup.jpg"
                    },
                    new Product
                    {
                        Name = "Тениска с български мотив",
                        Description = "Ръчно изработена тениска с уникален български етно дизайн.",
                        Price = 18.50m,
                        CategoryId = context.Categories.First(c => c.Name == "Handmade Souvenirs").Id,
                        ProducerId = context.Producers.First(p => p.Name == "Ръчно изработени сувенири").Id,
                        ImageUrl = "images/products/bulgarian_tee.jpg"
                    }
                };

                await context.Products.AddRangeAsync(products);  // Добавяме продуктите
                await context.SaveChangesAsync();  // Записваме в базата данни
            }
        }
    }
}
