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
        //Foreign Key Property
        public int ProductId { get; set; }
        public int LanguageId { get; set; }

<<<<<<< HEAD
        // İlişki
        public virtual Language Language { get; set; }
        public virtual Product Product { get; set; }
=======
>>>>>>> 4b6554a7615743909ab69f5e605d0908ac60ec9c
    }
}
