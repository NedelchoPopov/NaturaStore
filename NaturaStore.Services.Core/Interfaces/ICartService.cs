using NaturaStore.Data.Models;
using Microsoft.AspNetCore.Http;
using NaturaStore.Web.ViewModels.Cart;
using System;
using System.Threading.Tasks;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface ICartService
    {
        CartViewModel GetCart(HttpContext httpContext);
        void AddToCart(HttpContext httpContext, Product product, int quantity);
        void UpdateQuantity(HttpContext httpContext, Guid productId, int quantity);
        void RemoveFromCart(HttpContext httpContext, Guid productId);
    }
}
