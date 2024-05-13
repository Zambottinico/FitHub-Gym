using FluentValidation;
using static FitHub.Bussines.SubscriptionTypeBussines.Commands.DeleteSubscriptionType;
using static FitHub.Bussines.SubscriptionTypeBussines.Commands.PostSubscriptionType;

namespace FitHub.Bussines.SubscriptionTypeBussines.Validators
{
    public class SubscriptionTypeDeleteValidator : AbstractValidator<DeleteSubscriptionTypeCommand>
    {
        public SubscriptionTypeDeleteValidator() 
        {
            RuleFor(s => s.Id).NotEmpty().NotNull(); 
        }
    }
}
