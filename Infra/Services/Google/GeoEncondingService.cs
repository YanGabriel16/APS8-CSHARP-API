using System.Text;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Objects;
using Newtonsoft.Json;
using static APS8_CSHARP_API.Domain.Objects.GeoEncondinsObjects;

namespace APS8_CSHARP_API.Infra.Services.Google
{
    public class GeoCodeService : IGeoCodeService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiKey = "AIzaSyDX2Kjl6MYhu7y8x9WQiEmD_1F2W5s3OhE";

        public GeoCodeService()
            => _httpClient = new HttpClient();

        public async Task<Coordenadas?> ObterCoordenadasPorCEP(string cep)
        {
            string geocodingUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={cep}&key={ApiKey}";

            try
            {
                string geocodingResponse = await _httpClient.GetStringAsync(geocodingUrl);
                var geocodingResult = JsonConvert.DeserializeObject<GeocodingResult>(geocodingResponse);

                if (geocodingResult != null && geocodingResult.results.Count > 0)
                {
                    var location = geocodingResult.results[0].geometry.location;
                    return new Coordenadas { Latitude = location.lat, Longitude = location.lng };
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}