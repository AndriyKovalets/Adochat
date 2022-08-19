using Adochat.Application;
using Adochat.Persistence;
using Adochat.WebApi.AppConfig;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Adochat.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.SetupWebApi(Configuration);
            services.SetupCore(Configuration);
            services.SetupPersistence(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {

            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseCors("Policy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
