using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Cart;
using NaturaStore.Data.Repository.Interfaces;
using NaturaStore.Data.Models;

namespace NaturaStore.Services.Core
{
    public class SessionCartService : ICartService
    {
        private const string SessionKey = "Cart";
        private readonly IProductRepository _prodRepo;

        public SessionCartService(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public CartViewModel GetCart(HttpContext ctx)
        {
            var data = ctx.Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(data))
                return new CartViewModel();

            return JsonConvert.DeserializeObject<CartViewModel>(data)!;
        }

        public void AddToCart(HttpContext ctx, Product p, int qty)
        {
            var cart = GetCart(ctx);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == p.Id);
            if (item == null)
            {
                cart.Items.Add(new CartItemViewModel
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl ?? "",
                    UnitPrice = p.Price,
                    Quantity = qty
                });
            }
            else
            {
                item.Quantity += qty;
            }

            SaveCart(ctx, cart);
        }

        public void UpdateQuantity(HttpContext ctx, Guid productId, int quantity)
        {
            var cart = GetCart(ctx);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) return;

            if (quantity <= 0)
                cart.Items.Remove(item);
            else
                item.Quantity = quantity;

            SaveCart(ctx, cart);
        }

        public void RemoveFromCart(HttpContext ctx, Guid productId)
        {
            var cart = GetCart(ctx);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
                cart.Items.Remove(item);
            SaveCart(ctx, cart);
        }

        private void SaveCart(HttpContext ctx, CartViewModel cart)
        {
            var json = JsonConvert.SerializeObject(cart);
            ctx.Session.SetString(SessionKey, json);
        }
    }
}
