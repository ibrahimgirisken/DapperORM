using DapperORM.Domain.Entities;
using DapperORM.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> FindByNameAsync(string UserNameOrEmail);

        Task<Boolean> CheckPasswordSignInAsync(AppUser user);
    }
}
