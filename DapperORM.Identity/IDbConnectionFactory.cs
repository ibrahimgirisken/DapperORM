using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Identity
{
    /// <summary>
    /// A factory for creating instances of <see cref="IDbConnection"/>.
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// The connection string to use for connecting to Microsoft SQL Server.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Creates a new instance of the underlying <see cref="IDbConnection"/>.
        /// </summary>
        IDbConnection Create();
    }
}
