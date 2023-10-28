using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Enums;
using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Repository
{
    public class LocalRepository : BaseRepository<Local>, ILocalRepository
    {
        public LocalRepository(AppDbContext appDbContext) : base(appDbContext){ }

        public void Delete(int Id)
        {
            var local = DbSet.First(x => x.Id == Id);

            if (local.Status != Status.Excluido)
            {
                local.Status = Status.Excluido;
                _context.Update(local);
                SaveChanges();
            }
        }
    }
}