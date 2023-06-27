using Application.Common.Models;
using Application.MediatR.Member.EventHandlers;
using Application.MediatR.Member.Queries.GetAllMemberQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator= mediator;
        }
        // GET: api/<MembersController>
        [HttpPost]
        public async Task<ActionResult<IList<MemberDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllMemberQueryModel()));
        }
        [HttpGet]
        public async Task<ActionResult> Notification()
        {
           await _mediator.Publish(new MemberNotificationModel("hello"));
            return Ok();
        }
    }
}