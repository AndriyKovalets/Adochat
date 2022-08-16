using Adochat.Domain.Entities;
using Adochat.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Adochat.Persistence
{
    public static class StartupSetup
    {
        public static void SetupPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddIdentityDbContext();
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdochatDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddIdentityDbContext(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AdochatDbContext>();
        }
    }
}