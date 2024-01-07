using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public class ProductTranslation:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public Product Product { get; set; }
        public Language Language { get; set; }

    }
}
