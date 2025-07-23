using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderItemDetailsViewModel
    {
        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
