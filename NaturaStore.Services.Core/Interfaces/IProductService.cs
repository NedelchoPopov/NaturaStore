using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(CreateProductViewModel inputModel);
        Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync();
        Task<ProductDetailsViewModel?> GetProductByIdAsync(int id);
        Task<EditProductViewModel?> GetProductForEditAsync(int id);
        Task<bool> UpdateAsync(EditProductViewModel model);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetProducersAsync();
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(int id);
        Task<bool> DeleteProductAsync(int id);
    }
}