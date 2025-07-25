﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Models
{
    using Common.Enums;

    public class Order
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        
        public string UserId { get; set; } = null!; 
        public virtual ApplicationUserStore User { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        
        public decimal TotalPrice => OrderItems.Sum(i => i.Quantity * i.Price);

       
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        
        public bool IsDeleted { get; set; }
    }
}
