using FitHub.Bussines.MemberBussines.Validators;
using FitHub.Bussines.SubscriptionTypeBussines.Validators;
using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.MemberBussines.Commands
{
    public class PostMember
    {
        public class PostMemberCommand : IRequest<MemberDto>
        {
            public PostMemberCommand(string firstName, string lastName, string dni)
            {
                FirstName = firstName;
                LastName = lastName;
                Dni = dni;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Dni { get; set; }
        }
        public class PostMemberHandler : IRequestHandler<PostMemberCommand, MemberDto>
        {
            private readonly FitContext _context;
            private readonly MemberPostValidator _validations;

            public PostMemberHandler(FitContext context, MemberPostValidator validations)
            {
                _context = context;
                _validations = validations;

            }
            public async Task<MemberDto> Handle(PostMemberCommand request, CancellationToken cancellationToken)
            {
                _validations.Validate(request);
                Member member1 = await _context.Members.FirstOrDefaultAsync(m=>m.Dni==request.Dni);
                if (member1 !=null)
                {
                    throw new InvalidOperationException("El miembro ya existe en la base de datos.");
                }
                try
                {
                    Member member = new()
                    {
                        Dni = request.Dni,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                       
                    };
                   await _context.Members.AddAsync(member);
                   await _context.SaveChangesAsync();
                    MemberDto rta = new()
                    {
                        Dni = request.Dni,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Id = member.Id
                    };
                    return rta;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
