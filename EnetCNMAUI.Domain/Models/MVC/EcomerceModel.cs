using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{

    public class EcomerceModel
    {

        public string CardName { get; set; } = "";

        public string CardNumber { get; set; } = "";

        public string CardCCCode { get; set; } = "";

        public string CardExpMonth { get; set; } = "";

        public string CardExpYear { get; set; } = "";

        public string ZipCode { get; set; } = "";


    }
    public class EcomerceModelValidator : AbstractValidator<EcomerceModel>
    {
        public EcomerceModelValidator()
        {

            RuleFor(x => x.CardName).NotEmpty().WithMessage("Please enter Name");
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Card Number required");
            RuleFor(x => x.CardCCCode).NotEmpty().WithMessage("CCCode required");
            RuleFor(x => x.CardExpMonth).NotEmpty().WithMessage("Expiry month required").MaximumLength(2).WithMessage("Max 2 digit allow");
            RuleFor(x => x.CardExpYear).NotEmpty().WithMessage("Expiry year required");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode required");

            //  RuleFor(x => x.Iagree).Equal(true).WithMessage("You need to agree on the terms to proceed further");

        }
    }


}
