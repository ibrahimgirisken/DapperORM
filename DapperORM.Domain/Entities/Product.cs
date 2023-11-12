﻿using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Foreign Key Property
        public int CategoryId { get; set; }
    }
}
