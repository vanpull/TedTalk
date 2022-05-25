using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TedTalk.Application;
using TedTalk.Application.Contracts;
using TedTalk.Application.ObjectMapping;
using TedTalk.Data;
using TedTalk.Data.Repositories;
using TedTalk.Domain;
using TedTalk.Domain.Repositories;

namespace TedTalk.WebHost.HttpApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection WithAutoMapper(this IServiceCollection services)
        {
            var objectMappingAssemblies = new Assembly[] { typeof(EntityToDtoMappingProfile).Assembly };
            services.AddAutoMapper(objectMappingAssemblies);

            return services;
        }

        public static IServiceCollection WithCsvDataContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICsvDataContext<,>), typeof(CsvDataContext<,>)); 

            return services;
        }

        public static IServiceCollection WithDefaultRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICsvPathResolver, CsvPathResolver>();

            services.AddScoped(typeof(ITedRepository), typeof(TedRepository));

            return services;
        }

        public static IServiceCollection WithApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITedService, TedService>();

            return services;
        }

        public static IServiceCollection AddWebFramework(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpContextAccessor();

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped(serviceProvider =>
            {
                var actionContext = serviceProvider.GetService<IActionContextAccessor>().ActionContext;
                var urlHelperFactory = serviceProvider.GetService<IUrlHelperFactory>();
                return urlHelperFactory?.GetUrlHelper(actionContext);
            });

            return services;
        }

        public static IServiceCollection WithSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ted API", Version = "v1" });
                //c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "basic",
                //    Description = "Authorization header using the Basic scheme."
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                //        },
                //        new string[]{}
                //    }
                //});
            });

            return services;
        }
    }
}
