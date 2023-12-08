using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Domain.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Data
{
    public class DapperSignInManager: SignInManager<AppUser>
    {
        IDapperContext _dapperContext;
        public DapperSignInManager(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor,
                                 IUserClaimsPrincipalFactory<AppUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
                                 ILogger<SignInManager<AppUser>> logger, IAuthenticationSchemeProvider schemes)
         : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }

        public override async Task<SignInResult> CheckPasswordSignInAsync(AppUser user, string password, bool lockoutOnFailure)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // Dapper ile şifre kontrolü
            string query = $"SELECT PasswordHash FROM Users WHERE UserName = @UserName";
            var parameters = new { UserName = user.UserName };


            _dapperContext.Execute((conn) => {var hashedPassword = conn.Execute(query, parameters);});

            if (hashedPassword == null)
            {
                return SignInResult.Failed; // Kullanıcı bulunamadı
            }

            // Şifre kontrolü
            var passwordVerificationResult = UserManager.PasswordHasher.VerifyHashedPassword(user, hashedPassword, password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return SignInResult.Success; // Şifre doğrulandı
            }
            else
            {
                return SignInResult.Failed; // Şifre doğrulanamadı
            }
        }
    }
}
