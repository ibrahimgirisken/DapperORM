using Microsoft.AspNetCore.Identity;

namespace WebAPI.API.Data
{
    public class ExtendedIdentityRole:IdentityRole<string>
    {
        public ExtendedIdentityRole() { }

        public string Description { get; set; }
    }
}
