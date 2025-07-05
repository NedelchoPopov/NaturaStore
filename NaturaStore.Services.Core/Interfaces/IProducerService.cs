using NaturaStore.Data.Models;
using NaturaStore.Web.ViewModels.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Services.Core.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllProducersAsync();
        Task<int> CreateProducerAsync(CreateNewProducerViewModel model);
    }
}
