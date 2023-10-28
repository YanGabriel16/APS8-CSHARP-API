using System.Text;
using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Domain.Objects;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Services.Google
{
    public class AirQualityService : IAirQualityService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiKey = "AIzaSyDX2Kjl6MYhu7y8x9WQiEmD_1F2W5s3OhE";

        public AirQualityService()
            => _httpClient = new HttpClient();

        public async Task<AirQualityResponse> GetQualidadeAr(decimal latitude, decimal longitude)
        {
            string apiUrl = $"https://airquality.googleapis.com/v1/currentConditions:lookup?key={ApiKey}";

            var request = new
            {
                universalAqi = true,
                location = new
                {
                    latitude,
                    longitude
                },
                extraComputations = new[]
                {
                    "HEALTH_RECOMMENDATIONS",
                    "DOMINANT_POLLUTANT_CONCENTRATION",
                    "POLLUTANT_CONCENTRATION",
                    "LOCAL_AQI",
                    "POLLUTANT_ADDITIONAL_INFO"
                },
                languageCode = "pt"
            };

            string requestBody = JsonConvert.SerializeObject(request);

            StringContent content = new(requestBody, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AirQualityResponse>(responseContent) ?? new AirQualityResponse();
                }
                else
                {
                    throw new Exception($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Ocorreu um erro na requisição: {ex.Message}");
            }
        }
    }
}