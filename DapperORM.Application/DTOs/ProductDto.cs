using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.DTOs
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public List<ProductTranslationDto> ProductTranslations { get; set; }
    }
}
