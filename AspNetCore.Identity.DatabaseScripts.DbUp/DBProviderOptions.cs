using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Identity.DatabaseScripts.DbUp
{
    public class DBProviderOptions
    {
        public string DbSchema { get; set; } = "[dbo]";

        public string ConnectionString { get; set; }
    }
}
