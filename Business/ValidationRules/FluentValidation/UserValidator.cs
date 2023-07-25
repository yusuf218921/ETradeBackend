using Core.Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).Must(verify);
        }

        private bool verify(string arg)
        {
            if(arg.Contains("@"))
            {
                return true;
            }
            return false;
        }
    }
}
