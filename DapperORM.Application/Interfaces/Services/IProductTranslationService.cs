using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Services
{
    public interface IProductTranslationService:ITranslationService<Product,ProductTranslation>
    {
    }
}
