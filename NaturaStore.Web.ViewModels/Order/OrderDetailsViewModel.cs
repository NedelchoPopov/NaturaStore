namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; } = null!;
        public IList<OrderItemDetailsViewModel> Items { get; set; } = new List<OrderItemDetailsViewModel>();
    }
}
