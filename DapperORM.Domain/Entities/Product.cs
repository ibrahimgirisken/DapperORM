﻿using DapperORM.Domain.Common;
using DapperORM.Domain.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public class Product : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        // İlişki
        public ICollection<ProductTranslation> Translations { get; set; }
    }
}
