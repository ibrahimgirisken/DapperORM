using DapperORM.Application.Interfaces.DapperContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Context
{
    public class DapperContext : IDapperContext
    {
        IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task ExecuteAsync(Action<SqlConnection> @event)
        {
            using (var collection = GetConnection())
            {
                collection.Open();
                @event(collection);
            }
        }
    }
}
