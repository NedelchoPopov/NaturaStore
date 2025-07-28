using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using NaturaStore.Data.Common.Enums;

namespace NaturaStore.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; }
            = new HashSet<OrderItem>();

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public bool IsDeleted { get; set; }

        [NotMapped]
        public decimal TotalPrice => OrderItems.Sum(i => i.Quantity * i.Price);
    }


}
