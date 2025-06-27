using NaturaStore.Data.Models;

namespace NaturaStore.Data.Seeding
{
    public static class ProductSeeder
    {
        public static async Task SeedAsync(NaturaStoreDbContext context)
        {
            if (!context.Products.Any())
            {
                var firstCategory = context.Categories.First();
                var firstProducer = context.Producers.First();

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Козе сирене",
                        Description = "Домашно козе сирене от Родопите.",
                        Price = 14.50m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://example.com/images/koze-sirene.jpg"
                    },
                    new Product
                    {
                        Name = "Ябълки",
                        Description = "Сорт 'Флорина', свежи и хрупкави.",
                        Price = 3.20m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://example.com/images/yabalki.jpg"
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
