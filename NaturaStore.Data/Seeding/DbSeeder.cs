using Microsoft.EntityFrameworkCore;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Seeding
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(NaturaStoreDbContext context)
        {
            await CategorySeeder.SeedAsync(context);
            await ProducerSeeder.SeedAsync(context);
            await ProductSeeder.SeedAsync(context);
            
        }
    }
}
