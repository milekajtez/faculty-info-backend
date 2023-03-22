﻿using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Infrastructure.Mail.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FacultyInfo.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHashService, HashService>();
            serviceCollection.AddTransient<IMailService, MailService>();
        }
    }
}
