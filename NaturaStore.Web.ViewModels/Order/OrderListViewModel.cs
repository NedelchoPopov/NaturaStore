using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderListViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string Status { get; set; } = null!;
    }
}
