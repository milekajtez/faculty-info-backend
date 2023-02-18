using FacultyInfo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FacultyInfo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DataContext>(options => options.UseNpgsql(configuration["CONNECTION_STRING"]));
            serviceCollection.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(configuration["CORS_ORIGINS"].Split(','))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                });
            });

            serviceCollection.AddAutoMapper(typeof(ServiceCollectionExtensions));
            serviceCollection.AddHttpClient();
        }

        public static void AddSwaggerServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSwaggerGen(configureOptions =>
            {
                configureOptions.SwaggerDoc("FacultyInfoOpenAPISpecification", new OpenApiInfo
                {
                    Title = "Mesa WebAPI",
                    Version = "v1",
                    Description = "Mesa WebAPI specification"
                });
            });
        }
    }
}
