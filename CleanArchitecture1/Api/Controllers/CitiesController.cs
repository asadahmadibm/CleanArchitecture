
using Application.Cities.Commands.Create;
using Application.Cities.Commands.Delete;
using Application.Cities.Commands.Update;
using Application.Cities.Queries.GetCityById;
using Application.Common.Models;
using Application.Common.Security;
using Application.Dto;
using cleanarchitecture4.Application.Cities.Queries.GetCities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    /// <summary>
    /// Cities
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class CitiesController : ApiControllerBase
    {
        /// <summary>
        /// Get all cities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCities")]
        
        public async Task<ActionResult<ServiceResult<List<CityDto>>>> GetAllCities(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCitiesQuery(), cancellationToken));
        }

        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCityById")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetCityById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery { CityId = id }, cancellationToken));
        }

        /// <summary>
        /// Create city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Create(CreateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Update(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }, cancellationToken));
        }
    }
}