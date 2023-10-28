using APS8_CSHARP_API.Domain.Objects;

namespace APS8_CSHARP_API.Domain.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<OpenWeatherResponse> GetWeatherForecast(decimal lat, decimal lon);
    }
}
