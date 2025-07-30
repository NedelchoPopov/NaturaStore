//// NaturaStore.Services.Core/CartService.cs
//using NaturaStore.Data.Models;
//using NaturaStore.Data.Repository.Interfaces;
//using NaturaStore.Services.Core.Interfaces;
//using NaturaStore.Web.ViewModels.Cart;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NaturaStore.Services.Core
//{
//    public class CartService : ICartService
//    {
//        private readonly ICartRepository _cartRepo;
//        private readonly IProductRepository _prodRepo;

//        public CartService(ICartRepository cartRepo, IProductRepository prodRepo)
//        {
//            _cartRepo = cartRepo;
//            _prodRepo = prodRepo;
//        }

//        public async Task<CartViewModel> GetCartAsync(string userId)
//        {
//            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
//            if (cart == null)
//            {
//                cart = new Cart { Id = Guid.NewGuid(), UserId = userId };
//                await _cartRepo.AddAsync(cart);
//            }

//            var vm = new CartViewModel();
//            vm.Items = cart.Items
//                .Select(ci => new CartItemViewModel
//                {
//                    ProductId = ci.ProductId,
//                    Name = ci.Product.Name,
//                    ImageUrl = ci.Product.ImageUrl,
//                    Quantity = ci.Quantity,
//                    UnitPrice = ci.Price,
//                })
//                .ToList();

//            return vm;
//        }

//        public async Task<bool> AddToCartAsync(string userId, Guid productId, int quantity)
//        {
//            var cart = await _cartRepo.GetCartByUserIdAsync(userId)
//                       ?? new Cart { Id = Guid.NewGuid(), UserId = userId };

//            var product = await _prodRepo.GetByIdAsync(productId);
//            if (product == null) return false;

//            var existing = cart.Items.SingleOrDefault(ci => ci.ProductId == productId);
//            if (existing != null)
//            {
//                existing.Quantity += quantity;
//            }
//            else
//            {
//                cart.Items.Add(new CartItem
//                {
//                    Id = Guid.NewGuid(),
//                    CartId = cart.Id,
//                    ProductId = productId,
//                    Quantity = quantity,
//                    Price = product.Price
//                });
//            }

//            if (cart.Items.Count == 1)
//                return await _cartRepo.AddAsync(cart);
//            else
//                return await _cartRepo.UpdateAsync(cart);
//        }

//        public async Task<bool> UpdateQuantityAsync(string userId, Guid productId, int quantity)
//        {
//            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
//            if (cart == null) return false;

//            var item = cart.Items.SingleOrDefault(ci => ci.ProductId == productId);
//            if (item == null) return false;

//            if (quantity <= 0) cart.Items.Remove(item);
//            else item.Quantity = quantity;

//            return await _cartRepo.UpdateAsync(cart);
//        }

//        public async Task<bool> RemoveFromCartAsync(string userId, Guid productId)
//        {
//            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
//            if (cart == null) return false;

//            var item = cart.Items.SingleOrDefault(ci => ci.ProductId == productId);
//            if (item == null) return false;

//            cart.Items.Remove(item);
//            return await _cartRepo.UpdateAsync(cart);
//        }
//    }
//}
