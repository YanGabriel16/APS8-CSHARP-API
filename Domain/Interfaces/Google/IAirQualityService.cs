using APS8_CSHARP_API.Domain.Objects;

namespace APS8_CSHARP_API.Domain.Interfaces.Google
{
    public interface IAirQualityService
    {
        Task<AirQualityResponse> GetQualidadeAr(decimal latitude, decimal longitude);
    }
}