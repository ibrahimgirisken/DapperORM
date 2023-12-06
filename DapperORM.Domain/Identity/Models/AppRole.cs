using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;

namespace DapperORM.Domain.Identity.Models
{
    public class AppRole : IdentityRole
    {
        internal List<Claim> Claims { get; set; }
    }
}
