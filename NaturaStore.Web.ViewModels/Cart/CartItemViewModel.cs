﻿namespace NaturaStore.Web.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => UnitPrice * Quantity;
    }

}