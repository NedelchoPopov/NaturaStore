namespace NaturaStore.Services.Core
{
    using NaturaStore.Services.Core.Interfaces;
    using NaturaStore.Data.Repository.Interfaces;
    using NaturaStore.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Cart> GetCartAsync(string userId)
        {
            return await _cartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task<bool> AddToCartAsync(string userId, Guid productId)
        {
            var cart = await GetCartAsync(userId);
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
                return false;

            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                ProductId = productId,
                Quantity = 1,
                Price = product.Price
            };

            return await _cartRepository.AddItemToCartAsync(cart.Id, cartItem);
        }

        public async Task<bool> UpdateCartItemAsync(string userId, Guid productId, int newQuantity)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            var cartItem = await _cartRepository.GetCartItemAsync(cart.Id, productId);

            if (cartItem == null)
            {
                return false;
            }

            cartItem.Quantity = newQuantity;
            await _cartRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromCartAsync(string userId, Guid productId)
        {
            var cart = await GetCartAsync(userId);
            return await _cartRepository.RemoveItemFromCartAsync(cart.Id, productId);
        }
    }
}
