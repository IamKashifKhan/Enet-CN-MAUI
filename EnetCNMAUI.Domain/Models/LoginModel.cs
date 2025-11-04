using System;
using FluentValidation;

namespace EnetCNMAUI.Domain.Models
{
    public class LoginModel
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

    }
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password");
        }
    }

}

