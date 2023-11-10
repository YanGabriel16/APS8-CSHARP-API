using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Infra.Database;
using APS8_CSHARP_API.Infra.Repository;

namespace APS8_CSHARP_API.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILocalRepository _localRepository { get; set; }

        public ILocalRepository LocalRepository
        {
            get
            {
                return _localRepository = _localRepository ?? new LocalRepository(_dbContext);
            }
        }

        public ILocalInformacoesRepository _localInformacoesRepository { get; set; }

        public ILocalInformacoesRepository LocalInformacoesRepository
        {
            get
            {
                return _localInformacoesRepository = _localInformacoesRepository ?? new LocalInformacoesRepository(_dbContext);
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }
    }
}