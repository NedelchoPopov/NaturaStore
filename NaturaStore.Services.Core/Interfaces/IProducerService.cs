using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Producer;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProducerService
    {
        Task<Guid> CreateProducerAsync(CreateNewProducerViewModel model);  // Променено от int на Guid
        Task<IEnumerable<Producer>> GetAllProducersAsync();
        Task<bool> ProducerExistsAsync(Guid producerId);  // Променено от int на Guid
        Task<IEnumerable<SelectListItem>> GetProducersAsync();
    }
}