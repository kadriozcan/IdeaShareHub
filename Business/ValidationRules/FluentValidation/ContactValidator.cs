using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail cannot be empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject cannot be empty.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be empty.");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Enter at least 3 characters.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Enter at least 3 characters.");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Enter at least 20 characters.");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Enter up to 50 characters.");
        }
    }
}
