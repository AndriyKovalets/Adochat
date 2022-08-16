using Adochat.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adochat.Persistence.Data
{
    public class AdochatDbContext: IdentityDbContext<User>
    {
        public AdochatDbContext(DbContextOptions<AdochatDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
