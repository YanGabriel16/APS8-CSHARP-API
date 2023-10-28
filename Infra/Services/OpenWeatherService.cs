using System.Net.Http.Headers;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Objects;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "19e3ab596360c623819a6373f48c995a";

        public OpenWeatherService()
        {
            UriBuilder builder = new("https://api.openweathermap.org") { Path = "/data/2.5/" };
            _httpClient = new HttpClient { BaseAddress = new Uri(builder.ToString()) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OpenWeatherResponse> GetWeatherForecast(decimal lat, decimal lon)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"forecast?lat={lat}&lon={lon}&appid={_apiKey}&lang=pt_br&cnt=1");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<OpenWeatherResponse>(responseContent) ?? new OpenWeatherResponse();
                }
                else
                {
                    throw new Exception($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro na requisição: {ex.Message}");
            }
        }
    }
}
