using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DirectMessageValidator : AbstractValidator<DirectMessage>
    {
        public DirectMessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Receiver address is required!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required!");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Receiver address is not valid!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Please enter at least 3 characters.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Please enter at up to 100 characters.");


        }
    }
}
