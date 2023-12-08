

using DapperORM.Domain.Common;
using System.Security.Claims;

namespace DapperORM.Domain.Identity.Models
{
    public class AppUser : IBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email {  get; set; }
        public string PasswordHash { get; set; }
        public string NormalizedName { get; set; }
    }
}
