using NaturaStore.Data.Models;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order, Guid>, IAsyncRepository<Order, Guid>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> GetOrderWithItemsAsync(Guid id);
    }
}
