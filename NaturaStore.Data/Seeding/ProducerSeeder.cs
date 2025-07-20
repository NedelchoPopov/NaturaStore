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
            if (!context.Producers.Any())  // Проверка дали има вече производители в базата
            {
                var producers = new List<Producer>
                {
                    new Producer
                    {
                        Name = "Български мед",
                        Description = "Производител на натурален мед от българските планини, извлечен от местни пчели.",
                        Location = "Планина Рила, България",
                        ContactEmail = "info@bulgarianhoney.bg",
                        PhoneNumber = "+359123456789"
                    },

                    new Producer
                    {
                        Name = "Природен свят",
                        Description = "Ферма за органични билки и подправки, отглеждани в чистите български земи.",
                        Location = "Монтана, България",
                        ContactEmail = "contact@prirodensviat.bg",
                        PhoneNumber = "+359987654321"
                    },

                    new Producer
                    {
                        Name = "Ръчно изработени сувенири",
                        Description = "Магазин за ръчно изработени български сувенири, включващи керамика, текстил и дърворезба.",
                        Location = "София, България",
                        ContactEmail = "handmade@sofia.bg",
                        PhoneNumber = "+359112233445"
                    },

                    new Producer
                    {
                        Name = "Балканска ферма",
                        Description = "Производители на качествено българско сирене и млечни продукти, произведени по традиционни рецепти.",
                        Location = "Стара планина, България",
                        ContactEmail = "balcanfarm@bgsirene.bg",
                        PhoneNumber = "+359765432109"
                    },

                    new Producer
                    {
                        Name = "Натурални изкушения",
                        Description = "Производител на натурални сладка, конфитюри и мармалади от български плодове.",
                        Location = "Пловдив, България",
                        ContactEmail = "sales@naturaldelights.bg",
                        PhoneNumber = "+359345678901"
                    },

                    new Producer
                    {
                        Name = "Еко Храни България",
                        Description = "Производител на еко храни, отглеждани без пестициди, включително ориз, зърнени храни и бобови растения.",
                        Location = "Русе, България",
                        ContactEmail = "ecofoods@bulgaria.bg",
                        PhoneNumber = "+359234567890"
                    }
                };

                await context.Producers.AddRangeAsync(producers);
                await context.SaveChangesAsync();  
            }
        }
    }
}
