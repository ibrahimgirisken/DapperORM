using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public  class CategoryTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        //Foreign Key Property
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
    }
}
