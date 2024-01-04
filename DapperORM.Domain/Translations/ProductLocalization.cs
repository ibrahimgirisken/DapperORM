using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Translations
{
    public class ProductLocalization
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Language { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public virtual Product Product { get; set; }

    }
}
