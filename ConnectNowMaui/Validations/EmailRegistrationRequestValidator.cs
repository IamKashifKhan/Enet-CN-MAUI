using System;
using ConnectNow.Requests;
using ConnectNow.Requests.User;
using FluentValidation;

namespace ConnectNow.Validations
{
    public class EmailRegistrationRequestValidator : AbstractValidator<EmailRegisterRequest>
    {
        public EmailRegistrationRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a Valid Email");
        }
    }
}

