using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Adochat.WebApi.AppConfig
{
    public static class ServicesExtentions
    {
        public static void SetupWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGeneralServices();
            services.AddApiVersion();
            services.AddSwagger();
            services.AddCorsPolicy();
        }

        private static void AddGeneralServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        private static void AddApiVersion(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
                options.GroupNameFormat = "'v'VVV");
            services.AddApiVersioning();
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
        }

        private static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Policy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }
    }
}
