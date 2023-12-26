using DapperORM.Infrastructure.Data.Tables;
using DapperORM.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DapperORM.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityDependencies(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, ExtendedIdentityRole>(options => {
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddDapperStores(options => {
                options.AddRolesTable<ExtendedRolesTable, ExtendedIdentityRole>();
            })
            .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}



