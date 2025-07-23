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
        Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync();
        Task<OrderDetailsViewModel?> GetOrderDetailsAsync(Guid id);
        Task<bool> CreateOrderAsync(OrderCreateViewModel model);
        Task<bool> DeleteOrderAsync(Guid id);
        Task<OrderDeleteViewModel?> GetOrderForDeleteAsync(Guid id);
    }
}
