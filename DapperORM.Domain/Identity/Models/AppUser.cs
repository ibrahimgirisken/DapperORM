

using DapperORM.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DapperORM.Domain.Identity.Models
{
    public class AppUser : IdentityUser<string>,IBaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
