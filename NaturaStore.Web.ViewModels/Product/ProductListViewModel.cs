using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Product
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductItemViewModel> Items { get; set; } = new List<ProductItemViewModel>();

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public string? SearchTerm { get; set; }
    }

}
