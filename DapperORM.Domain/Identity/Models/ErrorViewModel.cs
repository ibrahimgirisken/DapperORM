using DapperORM.Domain.Common;

namespace DapperORM.Domain.Identity.Models
{
    public class ErrorViewModel:IBaseEntity
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
