namespace Adochat.WebApi.ServicesExtentions
{
    public static class ServicesExtentions
    {
        public static void SetupWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGeneralServices();
            services.AddSwagger();
            services.AddCorsPolicy();
        }

        private static void AddGeneralServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        private static void AddSwagger(this IServiceCollection services)
        {
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
