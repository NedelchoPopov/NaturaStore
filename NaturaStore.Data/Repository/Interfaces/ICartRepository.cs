using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart, Guid>, IAsyncRepository<Cart, Guid>
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task AddAsync(Cart cart);
        Task<bool> UpdateAsync(Cart cart);
        Task<CartItem?> GetCartItemAsync(Guid cartId, Guid productId);
        Task<bool> AddItemToCartAsync(Guid cartId, CartItem cartItem);
        Task<bool> RemoveItemFromCartAsync(Guid cartId, Guid productId);
        
    }
}
