using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FacultyInfo.Infrastructure.UnitOfWork;
using FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Infrastructure.Mail.Services;
using SendGrid;

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

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddTransient<IMailService>(x =>
                new MailService( 
                    configuration,
                    new SendGridClient(configuration["SENDGRID_KEY"]))
                );

            serviceCollection.AddAutoMapper(typeof(ServiceCollectionExtensions));
            serviceCollection.AddHttpClient();
        }

        public static void AddSwaggerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(configureOptions =>
            {
                configureOptions.SwaggerDoc("FacultyInfoOpenAPISpecification", new OpenApiInfo
                {
                    Title = "Faculty Info WebAPI",
                    Version = "v1",
                    Description = "Faculty Info WebAPI specification"
                });

                configureOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.OAuth2,
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddMediatorServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddMediatR(typeof(RegisterMainAdminCommandHandler));
        }
    }
}
