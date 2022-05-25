using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TedTalk.WebHost.HttpApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostEnvironment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;            
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddWebFramework()
                    .WithSwagger()
                    .WithAutoMapper()
                    .WithCsvDataContext()
                    .WithDefaultRepositories()
                    .WithApplicationServices();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c => {
                c.DocumentTitle = "Ted API Documentation";
                c.SwaggerEndpoint("/docs/v1/swagger.json", "Ted API v1");
                c.RoutePrefix = "docs";
            });

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
