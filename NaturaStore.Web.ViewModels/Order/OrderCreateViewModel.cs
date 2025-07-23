using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<Guid> ProductIds { get; set; } = new List<Guid>();

        public int Status { get; set; } = 0;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();
    }
}
