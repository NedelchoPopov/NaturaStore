using NaturaStore.Web.ViewModels.Order;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderCreateViewModel model);
        Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<OrderListViewModel>> GetUserOrdersAsync(string userId);
        Task<OrderDetailsViewModel?> GetOrderDetailsAsync(Guid id);
        Task<bool> DeleteOrderAsync(Guid id);
        
    }
}
