using DapperORM.Domain.Identity.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Create
{
    public class CreateUserValidator:AbstractValidator<AppUser>
    {
        public CreateUserValidator()
        {
            RuleFor(u=>u.UserName).NotEmpty();
            RuleFor(u => u.PasswordHash).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();

        }
    }
}
