using DapperORM.Application.Identity.Tables;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DapperORM.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var identityBuilder = services.AddIdentity<IdentityUser, ExtendedIdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
.AddDapperStores(options =>
{
    options.AddRolesTable<ExtendedRolesTable, ExtendedIdentityRole>();
})
.AddDefaultTokenProviders();

            // Diğer servis konfigürasyonları
            identityBuilder.Services.AddControllersWithViews();
            identityBuilder.Services.AddRazorPages();
        }
    }
}
