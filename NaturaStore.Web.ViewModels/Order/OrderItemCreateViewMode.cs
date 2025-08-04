namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderItemCreateViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
