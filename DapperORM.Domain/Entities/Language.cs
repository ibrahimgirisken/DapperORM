using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Code{ get; set; }
        public string Name { get; set; }
        public virtual List<ProductTranslation> Translations { get; set; }
    }
}
