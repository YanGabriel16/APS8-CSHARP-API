using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Interfaces;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IUnitOfWork _unitOfWork;
        public HangfireJobService(
            IOpenWeatherService openWeatherService,
            IUnitOfWork unitOfWork)
        {
            _openWeatherService = openWeatherService;
            _unitOfWork = unitOfWork;
        }

        public async void AdicionarDadosLocaisJob()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Job :: AdicionarDadosLocaisJob => Iniciado!");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            var locais = await _unitOfWork.LocalRepository.GetLocaisAtivos();

            if (!locais.Any()) return;

            try
            {
                foreach (var local in locais)
                {
                    var clima = await _openWeatherService.GetWeatherForecast(local.Latitude, local.Longitude);
                    var dado = new LocalInformacoes()
                    {
                        LocalId = local.Id,
                        ClimaticosJson = JsonConvert.SerializeObject(clima),
                    };

                    _unitOfWork.LocalInformacoesRepository.Add(dado);
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