using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Identity.Models;


namespace DapperORM.Persistence.Repositories
{
    public class DapperUserRepository : DapperGenericRepository<ErrorViewModel>, IUserRepository
    {
        public DapperUserRepository(IDapperContext dapperContext) : base(dapperContext, "Users")
        {

        }


        public async Task<ErrorViewModel> FindByNameAsync(string UserNameOrEmail)
        {
            var query = $"select * from Users where Name = @UserNameOrEmail or Email=@UserNameOrEmail";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return (ErrorViewModel)conn.Query<ErrorViewModel>(query);
            }
        }

        public async Task<bool> CheckPasswordSignInAsync(ErrorViewModel user)
        {
            var passwordHash = user.ShowRequestId;
            var query = $"select * from Users where PasswordHash = @passwordHash";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return conn.Query<ErrorViewModel>(query).Any();
            }
        }
    }
}

