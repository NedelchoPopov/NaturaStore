using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Models
{
    public class CartItem
    {
        public Guid Id { get; set; } // Уникален идентификатор за елемента в количката

        public Guid CartId { get; set; } // Свързаната количка
        public Cart Cart { get; set; } // Навигационен пропърти за количката

        public Guid ProductId { get; set; } // Идентификатор на продукта
        public Product Product { get; set; } // Навигационен пропърти за продукта

        public int Quantity { get; set; } // Количество на продукта в количката

        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // Цена на продукта към момента на добавяне в количката
    }
}
