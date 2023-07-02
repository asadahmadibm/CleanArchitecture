using Application.Cities.Commands.Create;
using Application.Common.Models;
using Application.Common.Models.AgGrid;
using Application.Dto;
using Application.MediatR.Ecarsales.Commands.Create;
using Application.MediatR.Ecarsales.Queries;
using Application.MediatR.Ecarsales.Queries.GetAllEcarsaleAgGridQuery;
using Application.MediatR.Ecarsales.Queries.GetAllEcarSaleQuery;
using cleanarchitecture4.Application.Cities.Queries.GetCities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EcarSalesController : ApiControllerBase
    {
        [HttpPost]
        [Route("GetAllNoFilter")]
        public async Task<ActionResult<ServiceResult<List<EcarsaleDTO>>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllEcarsaleQuery(), cancellationToken));
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResult<List<EcarsaleDTO>>>> GetAllForAgGrid(GetAllEcarsaleAgGridQuery getAllEcarsaleAgGridQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(getAllEcarsaleAgGridQuery, cancellationToken));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ServiceResult<EcarsaleDTO>>> Create(CreateEcarSaleCommand createEcarSaleCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(createEcarSaleCommand, cancellationToken));
        }



    }
}
