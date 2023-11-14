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
            var query = await _context.Set<Local>()
                .Where(x => x.Status == Status.Ativo)
                .ToListAsync();


            if (query != null)
            {
                var queryLocalInformacoes = await _context.Set<LocalInformacoes>()
                    .Where(x => x.Status == Status.Ativo)
                    .ToListAsync();

                foreach (var local in query)
                {
                    var localInformacoes = queryLocalInformacoes.Where(x => x.LocalId == local.Id);
                    foreach (var item in localInformacoes)
                    {
                        var clima = JsonConvert.DeserializeObject<OpenWeatherResponse>(item.ClimaticosJson, Constants.jsonSettings);
                        var dado = new LocalDadosObject(clima ?? new OpenWeatherResponse(), item.DataAtualizado);

                        local.Dados.Add(dado);
                    }

                    local.Dados = local.Dados.OrderByDescending(x => x.Data).ToList();
                    local.Dados = local.Dados.Distinct(new LocalDadosObjectDateComparer()).ToList();
                }
            }

            return query ?? new();
        }

        public async Task<Local> GetLocal(int Id)
        {
            var query = await _context.Set<Local>()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                var queryLocalInformacoes = await _context.Set<LocalInformacoes>()
                    .Where(x => x.Status == Status.Ativo && x.LocalId == query.Id)
                    .ToListAsync();

                foreach (var item in queryLocalInformacoes)
                {
                    var clima = JsonConvert.DeserializeObject<OpenWeatherResponse>(item.ClimaticosJson, Constants.jsonSettings);
                    var dado = new LocalDadosObject(clima ?? new OpenWeatherResponse(), item.DataAtualizado);

                    query.Dados.Add(dado);
                }

                query.Dados = query.Dados.OrderByDescending(x => x.Data).ToList();
                query.Dados = query.Dados.Distinct(new LocalDadosObjectDateComparer()).ToList();
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

        public async Task<Local> GetLocal(decimal latitude, decimal longitude)
        {
            var local = await _context.Set<Local>().FirstAsync(x => x.Latitude == latitude && x.Longitude == longitude && x.Status == Status.Ativo);
            return local ?? new Local(string.Empty, 0, 0);
        }
        #endregion
    }
}