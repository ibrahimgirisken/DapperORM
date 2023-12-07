

using DapperORM.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DapperORM.Domain.Identity.Models
{
    public class AppUser : IdentityUser,IBaseEntity
    {
        public string UserName { get; set; }
        public string Email {  get; set; }
        public string PasswordHash { get; set; }
    }
}
