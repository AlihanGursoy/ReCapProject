using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(800).When(c => c.ModelYear == 2009);
            RuleFor(c => c.Description).Must(StartWithM);
        }

        private bool StartWithM(string arg)
        {
            return arg.StartsWith("M");
        }
    }
}
