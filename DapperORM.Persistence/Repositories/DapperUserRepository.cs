using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Repositories
{
    public class DapperUserRepository : DapperGenericRepository<AppUser>, IUserRepository
    {
        public DapperUserRepository(IDapperContext dapperContext) : base(dapperContext, "Users")
        {
        }
    }
}
