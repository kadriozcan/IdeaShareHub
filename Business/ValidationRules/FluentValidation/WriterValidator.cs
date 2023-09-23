using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(w => w.Username).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(w => w.Username).MaximumLength(20).WithMessage("Please enter up to 20 characters.");

            RuleFor(w => w.AboutWriter).NotEmpty().WithMessage("About field cannot be empty.");

            RuleFor(w => w.Title).NotEmpty().WithMessage("Title field cannot be empty.");
        }
    }
}
