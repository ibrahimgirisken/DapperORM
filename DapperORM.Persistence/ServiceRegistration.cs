using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Interfaces.Services;
using DapperORM.Domain.Entities;
using DapperORM.Persistence.Context;
using DapperORM.Persistence.Repositories;
using DapperORM.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DapperORM.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddScoped<IProductTranslationService, ProductTranslationService>();

            services.AddScoped<IProductRepository, DapperProductRepository>();
            services.AddScoped<IProductTranslationRepository, DapperProductTranslationRepository>();
            services.AddScoped<ICategoryRepository, DapperCategoryRepository>();
        }
    }
}
