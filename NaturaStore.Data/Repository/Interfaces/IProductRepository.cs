using NaturaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface IProductRepository
        : IRepository<Product, int>, IAsyncRepository<Product, int>
    {
    }
}
