using FitHub.Bussines.MemberBussines.Validators;

using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.MemberBussines.Commands
{
    public class DeleteMember
    {
        public class DeleteMemberCommand : IRequest<MemberDto>
        {
            public DeleteMemberCommand(int id)
            {
                Id = id;
            }

            public int Id { get; set; }

        }
        public class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand, MemberDto>
        {
            private readonly FitContext _context;
            private readonly MemberDeleteValidator validations;

            public DeleteMemberHandler(FitContext context, MemberDeleteValidator validations)
            {
                _context = context;
                this.validations = validations;
            }

            public async Task<MemberDto> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
            {
                validations.Validate(request);
                try
                {
                    Member member = await _context.Members.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (member != null)
                    {
                        MemberDto rta = new()
                        {
                            Dni = member.Dni,
                            FirstName = member.FirstName,
                            LastName = member.LastName,
                            Id = member.Id
                        };
                         _context.Members.Remove(member);
                        await _context.SaveChangesAsync();
                        return rta;

                    }
                    throw new InvalidOperationException($"No se encontró la entidad con el ID {request.Id}.");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
