using NaturaStore.Data.Models;
using NaturaStore.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository
{
    public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
    {
        private readonly NaturaStoreDbContext _dbContext;

        public OrderRepository(NaturaStoreDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _dbContext.Orders
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        
        public async Task<Order?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
