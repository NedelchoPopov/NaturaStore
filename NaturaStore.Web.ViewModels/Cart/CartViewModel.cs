namespace NaturaStore.Web.ViewModels.Cart
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal GrandTotal => Items.Sum(i => i.Subtotal);
    }
}