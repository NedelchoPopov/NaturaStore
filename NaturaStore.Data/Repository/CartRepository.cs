namespace NaturaStore.Data.Repository
{
    using NaturaStore.Data.Models;
    using NaturaStore.Data.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartRepository : BaseRepository<Cart, Guid>, ICartRepository
    {
        public CartRepository(NaturaStoreDbContext dbContext)
            : base(dbContext)
        {
        }


        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var cart = await this.DbContext.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId);
            return cart ?? new Cart { Id = Guid.NewGuid(), UserId = userId }; // Връщаме нова количка, ако не е намерена
        }

        public async Task<bool> AddItemToCartAsync(Guid cartId, CartItem cartItem)
        {
            await this.DbContext.CartItems.AddAsync(cartItem);
            return await this.SaveChangesAsync() > 0; // Проверяваме дали записът е успешен
        }

        public async Task<bool> RemoveItemFromCartAsync(Guid cartId, Guid productId)
        {
            var cartItem = await this.DbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

            if (cartItem == null)
                return false;

            this.DbContext.CartItems.Remove(cartItem);
            return await this.SaveChangesAsync() > 0; // Проверяваме дали премахването е успешно
        }
        public async Task<CartItem> GetCartItemAsync(Guid cartId, Guid productId)
        {
            return await this.DbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        // Метод за запазване на промените в базата
        public async Task<int> SaveChangesAsync()
        {
            return await this.DbContext.SaveChangesAsync();
        }
    }
}
