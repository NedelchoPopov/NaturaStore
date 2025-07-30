using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
