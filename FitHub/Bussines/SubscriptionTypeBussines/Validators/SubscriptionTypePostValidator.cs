using FitHub.Bussines.SubscriptionTypeBussines.Commands;
using FluentValidation;
using static FitHub.Bussines.SubscriptionTypeBussines.Commands.PostSubscriptionType;

namespace FitHub.Bussines.SubscriptionTypeBussines.Validators
{
    public class SubscriptionTypePostValidator : AbstractValidator<PostSubscriptionTypeCommand>
    {
        public SubscriptionTypePostValidator() 
        {
            RuleFor(p=>p.Price).NotEmpty().NotNull();
            RuleFor(p=>p.Description).NotEmpty().NotNull();
        }
    }
}
