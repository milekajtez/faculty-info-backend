using FacultyInfo.Application.Helpers.Hash;
using Microsoft.Extensions.DependencyInjection;

namespace FacultyInfo.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHashService, HashService>();
        }
    }
}
