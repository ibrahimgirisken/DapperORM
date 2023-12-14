using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Identity
{
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDbConnection Create()
        {
            throw new NotImplementedException();
        }

        IDbConnection IDbConnectionFactory.Create()
        {
            throw new NotImplementedException();
        }
    }
}
