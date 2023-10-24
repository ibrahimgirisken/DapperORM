using DapperORM.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Common
{
    public static class CategoryRules
    {
        public static IRuleBuilder<T,string> CheckCategoryName<T>(
            this IRuleBuilder<T,string> ruleBuilder) where T:Category
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Kategori ismi boş geçilemez!")
                .MinimumLength(3).WithMessage("En az 3 karakterden oluşmalıdır!")
                .MaximumLength(70).WithMessage("Maksimum 70 karakter olmadırı!");
        }
    }
}
