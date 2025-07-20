using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }  

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Producer { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
