using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Domain.Constants
{
    public class ValidationMessages
    {
        //Product
        public const string Product_Name_Length_Error = "Ürün ismi zorunludur!";
        public const string Product_Name_Min_Length_Error = "Ürün ismi en az 3karakter olmalıdır!";
        public const string Product_Name_Max_Length_Error = "Ürün ismi en fazla 70 karakter olmalıdır!";
        public const string Category_Name_Length_Error = "Kategori ismi zorunludur!";
        public const string Category_Name_Min_Length_Error = "Kategori ismi en az 3karakter olmalıdır!";
        public const string Category_Name_Max_Length_Error = "Kategori ismi en fazla 70 karakter olmalıdır!";
    }
}
