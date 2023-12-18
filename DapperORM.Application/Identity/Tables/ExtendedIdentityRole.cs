using Microsoft.AspNetCore.Identity;

namespace DapperORM.Application.Identity.Tables
{
    public class ExtendedIdentityRole : IdentityRole<string>
    {
        public ExtendedIdentityRole() { }

        public string Description { get; set; }
    }
}