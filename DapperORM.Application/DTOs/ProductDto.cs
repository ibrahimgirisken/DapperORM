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
<<<<<<< HEAD
        public ICollection<ProductTranslationDto> Translations { get; set; }
=======
        public List<ProductTranslationDto> ProductTranslations { get; set; }
>>>>>>> 04d7e2d9894207aed0e82bc2a7ab7a255a5ddc74
    }
}
