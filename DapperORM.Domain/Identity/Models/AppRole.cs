using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using DapperORM.Domain.Common;

namespace DapperORM.Domain.Identity.Models
{
    public class AppRole : IdentityRole, IBaseEntity
    {
        internal List<Claim> Claims { get; set; }
    }
}
