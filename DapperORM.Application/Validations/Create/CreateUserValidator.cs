﻿using DapperORM.Domain.Identity.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Create
{
    public class CreateUserValidator:AbstractValidator<ErrorViewModel>
    {
        public CreateUserValidator()
        {
        }
    }
}
