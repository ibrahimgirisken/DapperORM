using DapperORM.Application.Abstractions;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Infrastructure.Services;
using DapperORM.Persistence.Repositories;
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

