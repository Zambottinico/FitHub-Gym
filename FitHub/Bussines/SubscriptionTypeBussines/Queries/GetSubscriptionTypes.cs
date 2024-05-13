using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.SubscriptionTypeBussines.Queries
{
    public class GetSubscriptionTypes
    {
        public class GetSubscriptionTypesCommand : IRequest<List<SubscriptionTypeDto>>
        {

        }
        public class GetSubscriptionTypesHandler : IRequestHandler<GetSubscriptionTypesCommand, List<SubscriptionTypeDto>>
        {
            private readonly FitContext _context;

            public GetSubscriptionTypesHandler(FitContext context)
            {
                _context = context;
            }

            public async Task<List<SubscriptionTypeDto>> Handle(GetSubscriptionTypesCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    List<SubscriptionTypeDto> rta = new List<SubscriptionTypeDto>();
                    List<SubscriptionType> subscriptionTypes = await _context.SubscriptionTypes.ToListAsync();
                    foreach (var subscriptionType in subscriptionTypes)
                    {
                        SubscriptionTypeDto typeDto = new()
                        {
                            Description = subscriptionType.Description,
                            Id=subscriptionType.Id,
                            Price=subscriptionType.Price
                        
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
