using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Create
{
    public class CreateUserValidator:AbstractValidator<IdentityUser>
    {
        public CreateUserValidator()
        {

        }
    }
}
