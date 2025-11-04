using System;
using EnetCNMAUI.Requests;
using EnetCNMAUI.Requests.User;
using FluentValidation;

namespace EnetCNMAUI.Validations
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

