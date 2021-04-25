using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(c => (int)c.ModelYear).GreaterThanOrEqualTo(1900);
            RuleFor(c => (int)c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.Description).MinimumLength(3);

            //custom rule. tanimlanan metot bool deger dondurmeli
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Araba adi A harfi ile baslamalidir.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
