namespace NaturaStore.Services.Core.Interfaces
{
    using NaturaStore.Data.Models;
    using System;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<Cart> GetCartAsync(string userId);
        Task<bool> AddToCartAsync(string userId, Guid productId);
        Task<bool> RemoveFromCartAsync(string userId, Guid productId);
    }
}
