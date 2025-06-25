using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NaturaStore.Data
{
    public class NaturaStoreDbContext : IdentityDbContext
    {
        public NaturaStoreDbContext(DbContextOptions<NaturaStoreDbContext> options)
            : base(options)
        {
        }

    }
}
