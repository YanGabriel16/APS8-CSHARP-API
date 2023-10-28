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
            UriBuilder builder = new UriBuilder("https://api.openweathermap.org");
            builder.Path = "/data/2.5/";
            string url = builder.ToString();

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OpenWeatherResponse> GetWeatherForecast(decimal lat, decimal lon)
        {
            string resultado = string.Empty;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"forecast?lat={lat}&lon={lon}&appid={_apiKey}&lang=pt_br&cnt=1"); // Insira o caminho do endpoint da API de destino aqui

                if (response.IsSuccessStatusCode)
                {
                    resultado = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    resultado = $"Erro na requisição: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                resultado = $"Ocorreu um erro: {ex.Message}";
            }

            return JsonConvert.DeserializeObject<OpenWeatherResponse>(resultado) ?? new OpenWeatherResponse();
        }
    }
}
