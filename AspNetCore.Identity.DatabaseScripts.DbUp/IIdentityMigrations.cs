using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Identity.DatabaseScripts.DbUp
{
    public interface IIdentityMigrations
    {
        bool UpgradeDatabase();
    }
}
