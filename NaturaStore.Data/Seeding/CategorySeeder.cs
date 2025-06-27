using NaturaStore.Data.Models;

namespace NaturaStore.Data.Seeding
{
    public static class CategorySeeder
    {
        public static async Task SeedAsync(NaturaStoreDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Млечни продукти",
                        Description = "Кашкавал, сирене и други."
                    },

                    new Category
                    {
                        Name = "Плодове",
                        Description = "Свежи и сезонни плодове."
                    },

                    new Category
                    {
                        Name = "Зеленчуци",
                        Description = "Био зеленчуци от местни ферми."
                    }

                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}
