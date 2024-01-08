﻿using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public class Category:IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [DapperIgnore]
        public virtual List<CategoryTranslation> Localizations { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
