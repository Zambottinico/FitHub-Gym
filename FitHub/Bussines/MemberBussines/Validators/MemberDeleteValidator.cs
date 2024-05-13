using FitHub.Bussines.SubscriptionTypeBussines.Commands;
using FluentValidation;
using static FitHub.Bussines.MemberBussines.Commands.DeleteMember;


namespace FitHub.Bussines.MemberBussines.Validators
{
    public class MemberDeleteValidator:AbstractValidator<DeleteMemberCommand>
    {
       public MemberDeleteValidator()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }
    }
}
