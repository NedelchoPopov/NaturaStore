using NaturaStore.Web.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Order
{
    public class CheckoutViewModel
    {
        public IEnumerable<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal GrandTotal { get; set; }
    }
}
