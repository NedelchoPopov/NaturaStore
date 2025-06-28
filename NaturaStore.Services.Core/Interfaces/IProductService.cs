using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<IEnumerable<SelectListItem>> GetAllCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetAllProducersAsync();
        Task AddProductAsync(CreateProductViewModel model);

    }
}
