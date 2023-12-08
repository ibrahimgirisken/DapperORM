using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Identity.Models;


namespace DapperORM.Persistence.Repositories
{
    public class DapperUserRepository : DapperGenericRepository<AppUser>, IUserRepository
    {
        public DapperUserRepository(IDapperContext dapperContext) : base(dapperContext, "Users")
        {

        }


        public async Task<AppUser> FindByNameAsync(string UserNameOrEmail)
        {
            var query = $"select * from Users where Name = @UserNameOrEmail or Email=@UserNameOrEmail";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return (AppUser)conn.Query<AppUser>(query);
            }
        }

        public async Task<bool> CheckPasswordSignInAsync(AppUser user)
        {
            var passwordHash = user.PasswordHash;
            var query = $"select * from Users where PasswordHash = @passwordHash";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return conn.Query<AppUser>(query).Any();
            }
        }
    }
}

