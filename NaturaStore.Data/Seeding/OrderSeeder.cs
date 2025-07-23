using NaturaStore.Data.Common.Enums;
using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Seeding
{
    public class OrderSeeder
    {
        public async Task SeedAsync(NaturaStoreDbContext context)
        {
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        CreatedOn = DateTime.UtcNow,
                        UserId = "test-user-id-1",  
                        Status = OrderStatus.Pending, 
                        IsDeleted = false,
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Id = Guid.NewGuid(),
                                ProductId = Guid.NewGuid(),  
                                Quantity = 2,
                                Price = 25.50m
                            }
                        }
                    },
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        CreatedOn = DateTime.UtcNow.AddDays(-1),
                        UserId = "test-user-id-2",  
                        Status = OrderStatus.Shipped,  
                        IsDeleted = false,
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Id = Guid.NewGuid(),
                                ProductId = Guid.NewGuid(),  
                                Quantity = 1,
                                Price = 50.00m
                            }
                        }
                    }
                };

                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }
        }
    }
}
