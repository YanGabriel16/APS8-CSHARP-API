using System.Text.RegularExpressions;
using APS8_CSHARP_API.Api.Requests;
using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Helpers;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Objects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class LocalController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IAirQualityService _airQualityService;
        private readonly IViaCEPService _viaCEPService;
        private readonly IUnitOfWork _unitOfWork;
        public LocalController(IOpenWeatherService openWeatherService, IAirQualityService airQualityService, IViaCEPService viaCEPService, IUnitOfWork unitfOfWork)
        {
            _openWeatherService = openWeatherService;
            _airQualityService = airQualityService;
            _viaCEPService = viaCEPService;
            _unitOfWork = unitfOfWork;
        }

        [HttpGet("Forecast")]
        public async Task<OpenWeatherResponse> GetForecastAsync(decimal latitude, decimal longitude)
        {
            var response = await _openWeatherService.GetWeatherForecast(latitude, longitude);
            return response;
        }

        [HttpGet("consulta/cep/{cep}")]
        public async Task<IActionResult> GetEnderecoPorCEP(string cep)
        {
            cep = RegexHelper.GetNumberRegex().Replace(cep, "");
            var response = await _viaCEPService.GetEndereco(cep);

            if (response == null) return BadRequest();
            return Ok(response);
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
            var response = await _unitOfWork.LocalRepository.GetLocal(id);
            return response;
        }

        [HttpGet("Locais")]
        public async Task<List<Local>> GetLocaisAtivos()
        {
            var response = await _unitOfWork.LocalRepository.GetLocaisAtivos(true);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocal(AdicionarLocalRequest request)
        {
            var novoLocal = new Local(request.Nome, request.Longitude, request.Latitude)
            {
                CEP = request.CEP,
                Cidade = request.Cidade,
                Estado = request.Estado,
                Pais = request.Pais
            };

            _unitOfWork.LocalRepository.Add(novoLocal);
            await _unitOfWork.Commit();

            var local = await _unitOfWork.LocalRepository.GetLocal(request.Latitude, request.Longitude);

            var clima = await _openWeatherService.GetWeatherForecast(local.Latitude, local.Longitude);
            var qualidadeAr = await _airQualityService.GetQualidadeAr(local.Latitude, local.Longitude);
            var dado = new LocalInformacoes()
            {
                LocalId = local.Id,
                ClimaticosJson = JsonConvert.SerializeObject(clima),
                QualidadeArJson = JsonConvert.SerializeObject(qualidadeAr)
            };

            _unitOfWork.LocalInformacoesRepository.Add(dado);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateLocal(int id, EditarLocalRequest request)
        {
            var local = await _unitOfWork.LocalRepository.GetLocal(id);
            if (local == null) return BadRequest();

            local.Nome = request.Nome;

            _unitOfWork.LocalRepository.Update(local);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var result = await _unitOfWork.LocalRepository.Delete(id);
            await _unitOfWork.Commit();

            if (result == false) return BadRequest();

            return Ok();
        }
    }
}