using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper;
using DapperORM.Application.Abstractions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            })
               .AddDapperStores(options =>
               {
                   options.ConnectionString = "my connectionString";
                   options.DbSchema = "my schema";
               });

        }
    }
}
