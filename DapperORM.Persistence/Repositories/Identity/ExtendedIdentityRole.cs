using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Repositories.Identity
{
    public class ExtendedIdentityRole : IdentityRole<string>
    {
        public ExtendedIdentityRole() { }

        public string Description { get; set; }
    }
}
