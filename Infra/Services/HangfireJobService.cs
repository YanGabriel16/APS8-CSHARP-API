using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Helpers;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IAirQualityService _airQualityService;
        private readonly IUnitOfWork _unitOfWork;
        public HangfireJobService(
            IOpenWeatherService openWeatherService,
            IAirQualityService airQualityService,
            IUnitOfWork unitOfWork)
        {
            _openWeatherService = openWeatherService;
            _airQualityService = airQualityService;
            _unitOfWork = unitOfWork;
        }

        public async void AdicionarDadosLocaisJob()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Job :: AdicionarDadosLocaisJob => Iniciado!");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            var locais = await _unitOfWork.LocalRepository.GetLocaisAtivos();

            if (!locais.Any()) return;
            // if (true) return; //TODO: para nao consumir requisicoes

            if (locais.Count > 5)
                locais = locais.Take(5).ToList();

            try
            {
                foreach (var local in locais)
                {
                    var clima = await _openWeatherService.GetWeatherForecast(local.Latitude, local.Longitude);
                    var qualidadeAr = await _airQualityService.GetQualidadeAr(local.Latitude, local.Longitude);
                    var dado = new LocalInformacoes()
                    {
                        LocalId = local.Id,
                        ClimaticosJson = JsonConvert.SerializeObject(clima),
                        QualidadeArJson = JsonConvert.SerializeObject(qualidadeAr)
                    };

                    local.LocalInformacoes.Add(dado);

                    local.LocalInformacoes = local.LocalInformacoes.Distinct(new LocalInformacoesDateComparer()).ToList();

                    _unitOfWork.LocalRepository.Update(local);
                }

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar/atualizar registros: " + ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Job :: AdicionarDadosLocaisJob => Não Concluido!");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                return;
            }

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Job :: AdicionarDadosLocaisJob => Concluido!");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}