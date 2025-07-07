using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository
{
    public class OrderRepository : BaseRepository<Order, Guid>
    {
        public OrderRepository(NaturaStoreDbContext dbContext) 
            : base(dbContext)
        {

        }
    }
}
