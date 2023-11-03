using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Persistence.Context;
using DapperORM.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, DapperProductRepository>();
            services.AddScoped<ICategoryRepository, DapperCategoryRepository>();
            services.AddScoped<IDapperContext, DapperContext>();
        }
    }
}
