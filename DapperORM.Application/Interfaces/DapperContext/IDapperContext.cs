using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.DapperContext
{
    public interface IDapperContext
    {
        public SqlConnection GetConnection();
        public void Execute(Action<SqlConnection> @event);

    }
}
