
using Application.Cities.Queries.GetCityById;
using Application.Common.Models;
using Application.Dto;
using Application.MediatR.Member.Queries.GetAllMemberQuery;
using Application.MediatR.Members.Commands.Create;
using Application.MediatR.Members.Commands.Delete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ApiControllerBase
    {
        // GET: api/<MembersController>
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<ServiceResult<IList<MemberDto>>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllMemberQuery(), cancellationToken));
        }
        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetCityById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetMemberByIdQuery { id = id }, cancellationToken));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ServiceResult<int>>> Add(CreateMemberCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<ServiceResult<int>>> Delete(DeleteMemberCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}