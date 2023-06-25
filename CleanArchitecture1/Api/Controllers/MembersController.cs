using Application.IService;
using Application.MediatR.Member;
using Application.MediatR.Member.GetAllMemberQuery;
using Domain.entity;
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
        [HttpGet]
        public async Task<ActionResult<IList<Member>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllMemberQueryModel()));
        }

    }
}