using APS8_CSHARP_API.Domain.Objects;

namespace APS8_CSHARP_API.Domain.Interfaces
{
    public interface IViaCEPService
    {
        Task<EnderecoObject?> GetEndereco(string cep);
    }
}