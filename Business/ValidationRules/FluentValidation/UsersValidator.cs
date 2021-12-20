using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersValidator:AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.EMail).Must(FinishWithCom);
        }

        private bool FinishWithCom(string arg)
        {
            return arg.Contains(".com");
        }

    }
}
