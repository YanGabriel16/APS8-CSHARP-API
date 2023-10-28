using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Objects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;
        public LocalController(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        [HttpGet("Forecast")]
        public async Task<OpenWeatherResponse> GetAsync(decimal latitude, decimal longitude)
        {
            var response = await _openWeatherService.GetWeatherForecast(latitude, longitude);
            return response;
        }
    }
}