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
    public static class ProductRules
    {
        public static IRuleBuilderOptions<T, string> CheckProductName<T>(this IRuleBuilder<T, string> ruleBuilder) where T:Product {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Name_Length_Error)
                .MinimumLength(3).WithMessage(ValidationMessages.Product_Name_Min_Length_Error)
                .MaximumLength(70).WithMessage(ValidationMessages.Product_Name_Max_Length_Error);

        }
    }
}
