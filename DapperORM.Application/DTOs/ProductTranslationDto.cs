﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.DTOs
{
    public class ProductTranslationDto
    {
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
    }
}
