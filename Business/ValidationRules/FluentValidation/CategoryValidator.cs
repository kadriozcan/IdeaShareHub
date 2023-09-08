using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Please enter up to 20 characters.");

            RuleFor(c => c.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}
