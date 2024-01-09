using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.DTOs
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public ICollection<ProductTranslationDto> Translations { get; set; }
    }
}
