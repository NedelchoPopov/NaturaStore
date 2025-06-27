using System;
using System.Collections.Generic;
using System.Linq;
using NaturaStore.Data.Models;

namespace NaturaStore.Data.Seeding
{
    public static class ProducerSeeder
    {
        public static async Task SeedAsync(NaturaStoreDbContext context)
        {
            if (!context.Producers.Any())
            {
                var producers = new List<Producer>
                {
                    new Producer 
                    { 
                        Name = "Ферма Родопи", 
                        Description = "Малка семейна ферма", 
                        Location = "Смилян", 
                        ContactEmail = "info@rodopi.bg", 
                        PhoneNumber = "0888123456" 
                    },

                    new Producer 
                    { 
                        Name = "Био Плевен", 
                        Description = "Производител на био плодове", 
                        Location = "Плевен", ContactEmail = "bio@pleven.bg", 
                        PhoneNumber = "0878654321" 
                    }
                };

                await context.Producers.AddRangeAsync(producers);
                await context.SaveChangesAsync();
            }
        }
    }
}
