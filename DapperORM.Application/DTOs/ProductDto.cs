﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.DTOs
{
    public class ProductDto
    {
        public List<ProductTranslationDto> Translations { get; set; } = new();
    }
}