using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using DapperORM.Domain.Common;

namespace DapperORM.Domain.Identity.Models
{
    public class AppRole :IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
