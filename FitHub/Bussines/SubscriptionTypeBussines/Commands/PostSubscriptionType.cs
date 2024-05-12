using FitHub.Bussines.SubscriptionTypeBussines.Validators;
using FitHub.Data;
using FitHub.Dtos;
using FitHub.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitHub.Bussines.SubscriptionTypeBussines.Commands
{
    public class PostSubscriptionType
    {
        public class PostSubscriptionTypeCommand : IRequest<SubscriptionTypePostResponse>
        {
            public required string Description { get; set; }
            public required decimal Price { get; set; }
        }
        public class PostSubscriptionTypeHandler : IRequestHandler<PostSubscriptionTypeCommand, SubscriptionTypePostResponse>
        {
            private readonly FitContext _context;
            private readonly SubscriptionTypePostValidator _validations;

            public PostSubscriptionTypeHandler(FitContext context, SubscriptionTypePostValidator validations)
            {
                this._context = context;
                this._validations = validations;
            }

            public async Task<SubscriptionTypePostResponse> Handle(PostSubscriptionTypeCommand request, CancellationToken cancellationToken)
            {
                _validations.Validate(request);
                try
                {
                    SubscriptionType subscriptionType = new()
                    {
                        Price = request.Price,
                        Description = request.Description
                    };
                   await _context.SubscriptionTypes.AddAsync(subscriptionType);
                   await _context.SaveChangesAsync();
                     SubscriptionTypePostResponse rta = new()
                    {
                        Price = request.Price,
                        Description = request.Description,
                        Id=subscriptionType.Id
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
