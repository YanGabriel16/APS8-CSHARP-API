namespace APS8_CSHARP_API.Domain.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<string> GetWeatherForecast(decimal lat, decimal lon);
    }
}
