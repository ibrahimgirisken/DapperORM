using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Common.Result
{
    public interface IDataResult<T>:IDataResult
    {
        public T Data { get; }
    }
}
