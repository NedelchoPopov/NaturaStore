using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Data.Repository.Interfaces;
using NaturaStore.Web.ViewModels.Order;
using NaturaStore.Data.Common.Enums;

namespace NaturaStore.Services.Core
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository; 

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Select(o => new OrderListViewModel
            {
                Id = o.Id,
                UserName = o.User.ApplicationUser.UserName,  
                CreatedOn = o.CreatedOn,
                Status = o.Status.ToString()
            }).ToList();
        }

        public async Task<OrderDetailsViewModel?> GetOrderDetailsAsync(Guid id)
        {
            var order = await _orderRepository.GetOrderWithItemsAsync(id); 

            if (order == null)
                return null;

            return new OrderDetailsViewModel
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                Status = order.Status.ToString(),
                OrderItems = order.OrderItems.Select(oi => new OrderItemDetailsViewModel
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()
            };
        }

        public async Task<bool> CreateOrderAsync(OrderCreateViewModel model)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                UserId = model.UserId,
                Status = Enum.Parse<OrderStatus>(model.Status.ToString())
            };

            
            foreach (var productId in model.ProductIds)
            {
                var product = await _productRepository.GetByIdAsync(productId); 
                if (product != null)
                {
                    var orderItem = new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = product.Price 
                    };

                    order.OrderItems.Add(orderItem);
                }
            }

            await _orderRepository.AddAsync(order);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                return false;

            
            order.IsDeleted = true;
            await _orderRepository.UpdateAsync(order);

            

            return true;
        }

        public async Task<OrderDeleteViewModel?> GetOrderForDeleteAsync(Guid id)
        {
            
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return null;

            
            return new OrderDeleteViewModel
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                Status = order.Status.ToString()
            };
        }
    }
}
