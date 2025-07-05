using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturaStore.Data;
using NaturaStore.Data.Models;
using NaturaStore.Services.Core.Interfaces;
using NaturaStore.Web.ViewModels.Producer;

namespace NaturaStore.Services.Core
{
    public class ProducerService : IProducerService
    {
        private readonly NaturaStoreDbContext _dbContext;

        public ProducerService(NaturaStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateProducerAsync(CreateNewProducerViewModel model)
        {
            var producer = new Producer
            {
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                ContactEmail = model.ContactEmail,
                PhoneNumber = model.PhoneNumber
            };

            _dbContext.Producers.Add(producer);
            await _dbContext.SaveChangesAsync();

            return producer.Id;
        }

        public async Task<IEnumerable<Producer>> GetAllProducersAsync()
        {
            return await _dbContext.Producers.ToListAsync();
        }

        public async Task<bool> ProducerExistsAsync(int producerId)
        {
            return await _dbContext.Producers.AnyAsync(p => p.Id == producerId);
        }

        public async Task<IEnumerable<SelectListItem>> GetProducersAsync()
        {
            return await _dbContext.Producers
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();
        }
    }
}
