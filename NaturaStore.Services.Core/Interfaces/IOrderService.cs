using NaturaStore.Web.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
