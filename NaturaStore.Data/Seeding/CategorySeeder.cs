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
                        Name = "Homemade Goodies",
                        Description = "Jams, compotes, herbs, honey, and cheese – all made with care and love"
                    },

                    new Category
                    {
                        Name = "Herbs & Teas",
                        Description = "Natural dried herbs from clean regions – perfect for tea or home remedies."
                    },

                    new Category
                    {
                        Name = "Handmade Souvenirs",
                        Description = "T-shirts, mugs, and bags with unique designs crafted by local artists."
                    }

                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}
