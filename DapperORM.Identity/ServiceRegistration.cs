using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.API.Data;
using WebAPI.API.Data.Tables;

namespace DapperORM.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityDependencies(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, ExtendedIdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddDapperStores(options =>
            {
                options.AddRolesTable<ExtendedRolesTable, ExtendedIdentityRole>();
            });
        }
    }
}
        
    

