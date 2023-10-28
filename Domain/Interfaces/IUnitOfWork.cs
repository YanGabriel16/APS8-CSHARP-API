using APS8_CSHARP_API.Domain.Interfaces.Repository;

namespace APS8_CSHARP_API.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILocalRepository LocalRepository { get; }
        ILocalInformacoesRepository LocalInformacoesRepository { get; }
        Task Commit();
    }
}