using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Common.Result
{
    public class ErrorDataReuslt<T>:DataResult<T>
    {
        public ErrorDataReuslt(T data,string message):base(data,false,message)
        {

        }
        public ErrorDataReuslt(T data):base(data,false)
        {

        }
    }
}
