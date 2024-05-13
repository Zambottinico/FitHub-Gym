using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.MemberBussines.Queries
{
    public class GetMembers
    {
        public class GetMembersCommand : IRequest<List<MemberDto>>
        {

        }
        public class GetMembersHandler : IRequestHandler<GetMembersCommand, List<MemberDto>>
        {
            private readonly FitContext _context;

            public GetMembersHandler(FitContext context)
            {
                _context = context;
            }

            public async Task<List<MemberDto>> Handle(GetMembersCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    List<MemberDto> rta = new List<MemberDto>();
                    List<Member> members = await _context.Members.ToListAsync();
                    foreach (var member in members)
                    {
                        MemberDto typeDto = new()
                        {
                            Dni = member.Dni,
                            FirstName=member.FirstName,
                            LastName=member.LastName,
                            Id=member.Id
                        
                        };
                        rta.Add(typeDto);
                    }
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
