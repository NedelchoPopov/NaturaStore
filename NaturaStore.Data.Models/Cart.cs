using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }  // Уникален идентификатор за количката
        public string UserId { get; set; }  // Идентификатор на потребителя, към когото принадлежи количката

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>(); // Списък с всички елементи в количката
    }
}
