using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Identity.DatabaseScripts.DbUp
{
    public static class IdentityServerDbScriptsExtensions
    {
        public static IServiceCollection AddIdentityDbUpDatabaseScripts(this IServiceCollection services, Action<DBProviderOptions> dbProviderOptionsAction = null)
        {
            var options = GetDefaultOptions();
            dbProviderOptionsAction?.Invoke(options);
            services.AddSingleton(options);
            services.TryAddTransient<IIdentityMigrations, Migrations>();
            return services;
        }
        public static DBProviderOptions GetDefaultOptions()
        {
            //config mssql
            var options = new DBProviderOptions();
            return options;
        }
    }
}
