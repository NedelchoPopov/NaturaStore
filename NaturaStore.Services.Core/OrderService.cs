using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Data.Repository.Interfaces;
using NaturaStore.Web.ViewModels.Order;
using NaturaStore.Data.Common.Enums;

namespace NaturaStore.Services.Core
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _prodRepo;
        private readonly ICartService _cartService;

        public OrderService(IOrderRepository orderRepo, IProductRepository prodRepo, ICartService cartService)
        {
            _orderRepo = orderRepo;
            _prodRepo = prodRepo;
            _cartService = cartService;
        }

        public async Task<bool> CreateOrderAsync(OrderCreateViewModel model)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                UserId = model.UserId,
                Status = OrderStatus.Pending  // по подразбиране
            };

            foreach (var itm in model.Items)
            {
                var prod = await _prodRepo.GetByIdAsync(itm.ProductId);
                if (prod == null) continue;

                order.OrderItems.Add(new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = prod.Id,
                    Quantity = itm.Quantity,
                    Price = prod.Price
                });
            }

            await _orderRepo.AddAsync(order);
            return true;
        }

        public async Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            return orders.Select(o => new OrderListViewModel
            {
                Id = o.Id,
                CreatedOn = o.CreatedOn,
                Status = o.Status.ToString()
            });
        }

        public async Task<IEnumerable<OrderListViewModel>> GetUserOrdersAsync(string userId)
        {
            var all = await _orderRepo.GetAllAsync();
            return all
                .Where(o => o.UserId == userId)
                .Select(o => new OrderListViewModel
                {
                    Id = o.Id,
                    CreatedOn = o.CreatedOn,
                    Status = o.Status.ToString()
                });
        }

        public async Task<OrderDetailsViewModel?> GetOrderDetailsAsync(Guid id)
        {
            var o = await _orderRepo.GetOrderWithItemsAsync(id);
            if (o == null) return null;

            return new OrderDetailsViewModel
            {
                Id = o.Id,
                CreatedOn = o.CreatedOn,
                Status = o.Status.ToString(),
                Items = o.OrderItems.Select(oi => new OrderItemDetailsViewModel
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()
            };
        }


        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var o = await _orderRepo.GetByIdAsync(id);
            if (o == null) return false;
            o.IsDeleted = true;
            await _orderRepo.UpdateAsync(o);
            return true;
        }
    }
}
