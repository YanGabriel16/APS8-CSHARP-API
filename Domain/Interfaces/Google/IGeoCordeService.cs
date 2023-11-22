using static APS8_CSHARP_API.Domain.Objects.GeoEncondinsObjects;

namespace APS8_CSHARP_API.Domain.Interfaces.Google
{
    public interface IGeoCodeService
    {
        Task<Coordenadas?> ObterCoordenadasPorCEP(string cep);
    }
}