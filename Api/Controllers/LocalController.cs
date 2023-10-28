using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Objects;
using Microsoft.AspNetCore.Mvc;

namespace APS8_CSHARP_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IAirQualityService _airQualityService;
        public LocalController(IOpenWeatherService openWeatherService, IAirQualityService airQualityService)
        {
            _openWeatherService = openWeatherService;
            _airQualityService = airQualityService;
        }

        [HttpGet("Forecast")]
        public async Task<OpenWeatherResponse> GetForecastAsync(decimal latitude, decimal longitude)
        {
            var response = await _openWeatherService.GetWeatherForecast(latitude, longitude);
            return response;
        }

        [HttpGet("QualidadeAr")]
        public async Task<AirQualityResponse> GetQualidadeArAsync(decimal latitude, decimal longitude)
        {
            var response = await _airQualityService.GetQualidadeAr(latitude, longitude);
            return response;
        }
    }
}