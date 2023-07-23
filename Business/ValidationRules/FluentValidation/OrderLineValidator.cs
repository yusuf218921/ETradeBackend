using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderLineValidator : AbstractValidator<OrderLine>
    {
        public OrderLineValidator()
        {
            RuleFor(o => o.Amount).GreaterThan(0);
            RuleFor(o=> o.UnitPrice).GreaterThan(0);
            RuleFor(o=> o.UnitTotal).GreaterThan(0);
        }

        
    }
}
