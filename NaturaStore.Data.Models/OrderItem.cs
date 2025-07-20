using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Models
{
    public class OrderItem
    {
        
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

       
        public Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }

        
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
