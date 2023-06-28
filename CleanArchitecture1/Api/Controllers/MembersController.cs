
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
        /// <summary>
        /// Get All Member
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResult<IList<MemberDto>>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllMemberQuery(), cancellationToken));
        }
        /// <summary>
        /// Get Member by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMemberById")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetMemberById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetMemberByIdQuery { id = id }, cancellationToken));
        }
        /// <summary>
        /// Add Member
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ServiceResult<int>>> Add(CreateMemberCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
        /// <summary>
        /// Delete Member
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<ServiceResult<int>>> Delete(DeleteMemberCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}