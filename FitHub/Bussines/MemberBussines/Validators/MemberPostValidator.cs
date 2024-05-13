using FluentValidation;
using static FitHub.Bussines.MemberBussines.Commands.PostMember;


namespace FitHub.Bussines.MemberBussines.Validators
{
    public class MemberPostValidator:AbstractValidator<PostMemberCommand>
    {
       public MemberPostValidator()
        {
            RuleFor(m => m.Dni).NotEmpty().NotNull();
        }
    }
}
