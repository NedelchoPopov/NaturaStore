namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderItemDetailsViewModel
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
