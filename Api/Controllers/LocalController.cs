using APS8_CSHARP_API.Api.Requests;
using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Interfaces.Repository;
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
        private readonly ILocalRepository _repository;
        public LocalController(IOpenWeatherService openWeatherService, IAirQualityService airQualityService, ILocalRepository repository)
        {
            _openWeatherService = openWeatherService;
            _airQualityService = airQualityService;
            _repository = repository;
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

        [HttpGet("Local/{id}")]
        public async Task<Local> GetLocal(int id)
        {
            var response = await _repository.GetLocal(id);
            return response;
        }

        [HttpGet("Locais")]
        public async Task<List<Local>> GetLocaisAtivos()
        {
            var response = await _repository.GetLocaisAtivos();
            return response;
        }

        [HttpPost]
        public IActionResult AddLocal(AdicionarLocalRequest request)
        {
            var novoLocal = new Local(request.Nome, request.Longitude, request.Latitude);
            _repository.Add(novoLocal);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var result = await _repository.Delete(id);

            if(result == false) return BadRequest();

            return Ok();
        }
    }
}