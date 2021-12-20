using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomersValidator:AbstractValidator<Customer>
    {
        public CustomersValidator()
        {
            RuleFor(c => c.CompanyName).MinimumLength(1);
            RuleFor(c => c.CompanyName).NotEmpty();
        }
    }
}
