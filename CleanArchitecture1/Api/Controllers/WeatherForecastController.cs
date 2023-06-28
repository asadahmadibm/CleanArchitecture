using Application.Common.Models;
using Application.Dto;
using Application.WeatherForecasts.Queries.GetCurrentWeatherForecastQuery;
using Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("Get")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecasts());
    }

    /// <summary>
    /// Get current forecast from open weather services.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetCurrentWeather")]
    public async Task<ActionResult<ServiceResult<CurrentWeatherForecastDto>>> GetCurrentWeather([FromQuery] GetCurrentWeatherForecastQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }
}
