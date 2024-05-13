using FitHub.Bussines.SubscriptionTypeBussines.Validators;
using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.SubscriptionTypeBussines.Commands
{
    public class DeleteSubscriptionType
    {
        public class DeleteSubscriptionTypeCommand : IRequest<SubscriptionTypeDto>
        {
            public DeleteSubscriptionTypeCommand(int id)
            {
                Id = id;
            }

            public int Id { get; set; }

        }
        public class DeleteSubscriptionTypeHandler : IRequestHandler<DeleteSubscriptionTypeCommand, SubscriptionTypeDto>
        {
            private readonly FitContext _context;
            private readonly SubscriptionTypeDeleteValidator validations;

            public DeleteSubscriptionTypeHandler(FitContext context, SubscriptionTypeDeleteValidator validations)
            {
                _context = context;
                this.validations = validations;
            }

            public async Task<SubscriptionTypeDto> Handle(DeleteSubscriptionTypeCommand request, CancellationToken cancellationToken)
            {
                validations.Validate(request);
                try
                {
                    SubscriptionType subscriptionType = await _context.SubscriptionTypes.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (subscriptionType != null)
                    {
                        SubscriptionTypeDto rta = new()
                        {
                            Description = subscriptionType.Description,
                            Id = subscriptionType.Id,
                            Price = subscriptionType.Price
                        };
                         _context.SubscriptionTypes.Remove(subscriptionType);
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
