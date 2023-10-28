using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Enums;
using APS8_CSHARP_API.Domain.Helpers;
using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Domain.Objects;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace APS8_CSHARP_API.Infra.Repository
{
    public class LocalRepository : BaseRepository<Local>, ILocalRepository
    {
        public LocalRepository(AppDbContext appDbContext) : base(appDbContext) { }

        #region Consultas
        public async Task<List<Local>> GetLocaisAtivos()
        {
            var query = await _context.Set<Local>().Where(x => x.Status == Status.Ativo).ToListAsync();
            return query;
        }

        public async Task<Local> GetLocal(int Id)
        {
            var query = await _context.Set<Local>()
                .Where(x => x.Id == Id)
                .Include(x => x.Informacoes)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                foreach (var item in query.Informacoes)
                {
                    var qualidadeAr = JsonConvert.DeserializeObject<AirQualityResponse>(item.QualidadeArJson, Constants.jsonSettings);
                    var clima = JsonConvert.DeserializeObject<OpenWeatherResponse>(item.ClimaticosJson, Constants.jsonSettings);
                    var dado = new LocalDadosObject(qualidadeAr ?? new AirQualityResponse(), clima ?? new OpenWeatherResponse());

                    query.Dados.Add(dado);
                }

                query.Informacoes = new List<LocalInformacoes>();
            }

            return query ?? new Local(string.Empty, 0, 0);
        }
        #endregion

        #region Outros
        public async Task<bool> Delete(int Id)
        {
            var local = await _context.Set<Local>().FirstAsync(x => x.Id == Id);

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