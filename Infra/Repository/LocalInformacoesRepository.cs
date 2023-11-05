using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Enums;
using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Repository
{
    public class LocalInformacoesRepository : BaseRepository<LocalInformacoes>, ILocalInformacoesRepository
    {
        public LocalInformacoesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        #region Outros
        public async Task<bool> Delete(int Id)
        {
            var local = await _context.Set<LocalInformacoes>().FirstAsync(x => x.Id == Id);

            if (local.Status != Status.Excluido)
            {
                local.Status = Status.Excluido;
                _context.Update(local);
                return true;
            }
            return false;
        }
        #endregion
    }
}