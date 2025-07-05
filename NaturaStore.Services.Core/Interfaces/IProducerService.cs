using Microsoft.AspNetCore.Mvc.Rendering;
using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Producer;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProducerService
    {
        Task<int> CreateProducerAsync(CreateNewProducerViewModel model);
        Task<IEnumerable<Producer>> GetAllProducersAsync();
        Task<bool> ProducerExistsAsync(int producerId);
        Task<IEnumerable<SelectListItem>> GetProducersAsync();
    }
}