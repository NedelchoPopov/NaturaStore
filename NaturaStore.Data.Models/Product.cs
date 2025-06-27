using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; } = null!;
    }
}
