using NaturaStore.Web.ViewModels.Cart;

namespace NaturaStore.Web.ViewModels.Order
{
    public class CheckoutViewModel
    {
        public IEnumerable<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal GrandTotal { get; set; }
    }
}
