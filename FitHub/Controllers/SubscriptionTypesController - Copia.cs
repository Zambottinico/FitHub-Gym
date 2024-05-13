using FitHub.Bussines.SubscriptionTypeBussines.Commands;
using FitHub.Bussines.SubscriptionTypeBussines.Queries;
using FitHub.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static FitHub.Bussines.MemberBussines.Commands.DeleteMember;
using static FitHub.Bussines.MemberBussines.Commands.PostMember;
using static FitHub.Bussines.MemberBussines.Queries.GetMembers;
using static FitHub.Bussines.SubscriptionTypeBussines.Commands.DeleteSubscriptionType;
using static FitHub.Bussines.SubscriptionTypeBussines.Commands.PostSubscriptionType;
using static FitHub.Bussines.SubscriptionTypeBussines.Queries.GetSubscriptionType;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SubscriptionTypesController>
        [HttpGet]
        public async Task<List<MemberDto>> Get()
        {
            return await _mediator.Send(new GetMembersCommand());
        }

        // GET api/<SubscriptionTypesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubscriptionTypesController>
        [HttpPost]
        public async Task<MemberDto> Post([FromBody] PostMemberCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<SubscriptionTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubscriptionTypesController>/5
        [HttpDelete("{id}")]
        public async Task<MemberDto> DeleteAsync(int id)
        {
            return await _mediator.Send(new DeleteMemberCommand(id));
        }
    }
}
