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

                if (firstCategory == null || firstProducer == null)
                    return;

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Козе сирене",
                        Description = "Домашно козе сирене от Родопите.",
                        Price = 14.50m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://samorozi.com/image/cache/data/1%20roza/produkti/koze-sirene-0500-kg-800x800.jpg"
                    },
                    new Product
                    {
                        Name = "Ябълки",
                        Description = "Сорт 'Флорина', свежи и хрупкави.",
                        Price = 3.20m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://coop.hrankoop.com/storage/images/medium/354cd8045b483fb22ee828a3df73b581.jpg"
                    },

                    new Product
                    {
                        Name = "Краве сирене",
                        Description = "Натурално краве сирене от ферма в Троян.",
                        Price = 12.90m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://api.bulmag.org/images/028d07dce0b663e8febd0af9b7b0ca45.jpeg"
                    },

                    new Product
                    {
                        Name = "Бяло саламурено сирене",
                        Description = "Традиционно българско бяло сирене в саламура.",
                        Price = 11.40m,
                        CategoryId = firstCategory.Id,
                        ProducerId = firstProducer.Id,
                        ImageUrl = "https://nivabg.com/wp-content/uploads/2025/02/Ovchesirene.jpeg"
                    },
                };

                Console.WriteLine(">>> Seeding Products...");
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
