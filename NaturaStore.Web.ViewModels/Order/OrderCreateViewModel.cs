using NaturaStore.Data.Common.Enums;

namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        public string UserId { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItemCreateViewModel> Items { get; set; } = new();
    }
}
