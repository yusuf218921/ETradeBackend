using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TelValidation : AbstractValidator<TelNumber>
    {
        public TelValidation()
        {
            RuleFor(t=> t.PhoneNumber).Length(11);
            RuleFor(t => t.PhoneNumber).Must(StartWithZero);
        }

        private bool StartWithZero(string arg)
        {
            return arg[0] == '0' ? true:false;*0
        }
    }
}
