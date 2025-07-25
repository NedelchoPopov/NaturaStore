﻿using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Product;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(CreateProductViewModel inputModel);
        Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync();
        Task<ProductDetailsViewModel?> GetProductByIdAsync(Guid id);  // Променено от int на Guid
        Task<EditProductViewModel?> GetProductForEditAsync(Guid id);  // Променено от int на Guid
        Task<bool> UpdateAsync(EditProductViewModel model);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetProducersAsync();
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(Guid id);  // Променено от int на Guid
        Task<bool> DeleteProductAsync(Guid id);  // Променено от int на Guid
    }
}