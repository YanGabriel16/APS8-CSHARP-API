using System.Text;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Objects;
using APS8_CSHARP_API.Infra.Services.Google;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Services
{
    public class ViaCEPService : IViaCEPService
    {
        private readonly IGeoCodeService _geoCodeService;
        public ViaCEPService(IGeoCodeService geoCodeService)
            => _geoCodeService = geoCodeService;

        public async Task<EnderecoObject?> GetEndereco(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    var endereco = JsonConvert.DeserializeObject<EnderecoObject>(response);

                    if (endereco != null)
                    {
                        var coordenadas = await _geoCodeService.ObterCoordenadasPorCEP(cep);
                        endereco.Latitude = (decimal)coordenadas.Latitude;
                        endereco.Longitude = (decimal)coordenadas.Longitude;
                        return endereco;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Erro na requisição");
                }
            }
        }
    }
}