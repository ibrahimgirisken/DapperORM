using DapperORM.Application.Identity;
using DapperORM.Domain.Identity.Models;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ErrorViewModel>
    {
        Task<ErrorViewModel> FindByNameAsync(string UserNameOrEmail);

        Task<Boolean> CheckPasswordSignInAsync(ErrorViewModel user);
        void Add(ErrorViewModel user);
    }
}
