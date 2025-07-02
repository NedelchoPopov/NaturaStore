using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Producer>> GetAllProducersAsync();
        Task AddProductAsync(CreateProductViewModel model);

    }
}
