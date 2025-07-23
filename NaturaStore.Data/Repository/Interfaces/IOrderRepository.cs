using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface IOrderRepository
        : IRepository<Order, Guid>, IAsyncRepository<Order, Guid>
    {
        
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order?> GetOrderWithItemsAsync(Guid orderId);
    }
}
