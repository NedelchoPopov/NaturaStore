//using Microsoft.EntityFrameworkCore;
//using NaturaStore.Data;
//using NaturaStore.Data.Models;
//using NaturaStore.Data.Repository.Interfaces;
//using System.Threading.Tasks;

//namespace NaturaStore.Data.Repository
//{
//    public class CartRepository : ICartRepository
//    {
//        private readonly NaturaStoreDbContext _db;
//        public CartRepository(NaturaStoreDbContext db) => _db = db;

//        public async Task<Cart?> GetCartByUserIdAsync(string userId)
//        {
//            return await _db.Carts
//                .Include(c => c.Items)
//                    .ThenInclude(ci => ci.Product)
//                .FirstOrDefaultAsync(c => c.UserId == userId);
//        }

//        public async Task<bool> AddAsync(Cart cart)
//        {
//            try
//            {
//                await _db.Carts.AddAsync(cart);
//                await _db.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> UpdateAsync(Cart cart)
//        {
//            try
//            {
//                // Ако е детачнат, прикачаме, после SaveChanges
//                if (_db.Entry(cart).State == EntityState.Detached)
//                {
//                    _db.Carts.Attach(cart);
//                    _db.Entry(cart).State = EntityState.Modified;
//                }
//                await _db.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}
