using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> QueryAll();
        Task AddProductAsync(CreateProductViewModel inputModel);
        Task<IEnumerable<ProductItemViewModel>> GetAllProductsAsync();
        Task<ProductDetailsViewModel?> GetProductByIdAsync(Guid id); 
        Task<EditProductViewModel?> GetProductForEditAsync(Guid id);  
        Task<bool> UpdateAsync(EditProductViewModel model);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetProducersAsync();
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(Guid id);  
        Task<bool> DeleteProductAsync(Guid id);  
    }
}