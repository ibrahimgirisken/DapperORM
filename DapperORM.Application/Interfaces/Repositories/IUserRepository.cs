using DapperORM.Application.Identity.Models;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ErrorViewModel>
    {
        Task<ErrorViewModel> FindByNameAsync(string UserNameOrEmail);

        Task<Boolean> CheckPasswordSignInAsync(ErrorViewModel user);
        void Add(ErrorViewModel user);
    }
}
