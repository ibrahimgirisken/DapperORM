using DapperORM.Domain.Constants;
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
        public static IRuleBuilderOptions<T,string> CheckCategoryName<T>(
            this IRuleBuilder<T,string> ruleBuilder) where T:Category
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Category_Name_Length_Error)
                .MinimumLength(3).WithMessage(ValidationMessages.Category_Name_Min_Length_Error)
                .MaximumLength(70).WithMessage(ValidationMessages.Category_Name_Max_Length_Error);
        }
    }

}
