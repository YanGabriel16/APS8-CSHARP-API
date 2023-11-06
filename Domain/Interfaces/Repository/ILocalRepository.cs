using APS8_CSHARP_API.Domain.Entidades;

namespace APS8_CSHARP_API.Domain.Interfaces.Repository
{
    public interface ILocalRepository : IBaseRepository<Local>
    {
        Task<List<Local>> GetLocaisAtivos();
        Task<Local> GetLocal(int Id);
        Task<Local> GetLocal(decimal latitude, decimal longitude);
        Task<bool> Delete(int Id);
    }
}