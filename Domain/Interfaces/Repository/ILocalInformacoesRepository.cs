using APS8_CSHARP_API.Domain.Entidades;

namespace APS8_CSHARP_API.Domain.Interfaces.Repository
{
    public interface ILocalInformacoesRepository : IBaseRepository<LocalInformacoes>
    {
        Task<bool> Delete(int Id);
    }
}