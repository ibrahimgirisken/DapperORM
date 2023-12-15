using DapperORM.Application.Abstractions;
using DapperORM.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DapperORM.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureDependencies(this IServiceCollection servisCollection)
        {
            servisCollection.AddScoped<ITokenHandler, TokenHandler>();
        }

    }
}

