using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        public string UserId { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItemCreateViewModel> Items { get; set; } = new();
    }
}
