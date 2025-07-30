using NaturaStore.Data.Models;
using Microsoft.AspNetCore.Http;
using NaturaStore.Web.ViewModels.Cart;
using System;
using System.Threading.Tasks;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface ICartService
    {
        CartViewModel GetCart(HttpContext ctx);
        void AddToCart(HttpContext ctx, Product p, int qty);
        void RemoveFromCart(HttpContext ctx, Guid productId);
        void UpdateQuantity(HttpContext ctx, Guid productId, int quantity);
        void ClearCart(HttpContext ctx);
        
    }
}
