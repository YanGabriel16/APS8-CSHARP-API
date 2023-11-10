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
        public async Task<List<Local>> GetLocaisAtivos(bool limparLocalInformacoes = false)
        {
            var query = await _context.Set<Local>()
                .Where(x => x.Status == Status.Ativo)
                .Include(x => x.LocalInformacoes)
                .ToListAsync();

            if (query != null)
            {
                foreach (var local in query)
                {
                    foreach (var item in local.LocalInformacoes)
                    {
                        var qualidadeAr = JsonConvert.DeserializeObject<AirQualityResponse>(item.QualidadeArJson, Constants.jsonSettings);
                        var clima = JsonConvert.DeserializeObject<OpenWeatherResponse>(item.ClimaticosJson, Constants.jsonSettings);
                        var dado = new LocalDadosObject(qualidadeAr ?? new AirQualityResponse(), clima ?? new OpenWeatherResponse(), item.DataAtualizado);

                        local.Dados.Add(dado);
                    }

                    local.Dados = local.Dados.OrderByDescending(x => x.Data).ToList();
                    local.Dados = local.Dados.Distinct(new LocalDadosObjectDateComparer()).ToList();

                    if(limparLocalInformacoes == true)
                        local.LocalInformacoes = new List<LocalInformacoes>();
                }
            }

            return query ?? new();
        }

        public async Task<Local> GetLocal(int Id)
        {
            var query = await _context.Set<Local>()
                .Where(x => x.Id == Id)
                .Include(x => x.LocalInformacoes)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                foreach (var item in query.LocalInformacoes)
                {
                    var qualidadeAr = JsonConvert.DeserializeObject<AirQualityResponse>(item.QualidadeArJson, Constants.jsonSettings);
                    var clima = JsonConvert.DeserializeObject<OpenWeatherResponse>(item.ClimaticosJson, Constants.jsonSettings);
                    var dado = new LocalDadosObject(qualidadeAr ?? new AirQualityResponse(), clima ?? new OpenWeatherResponse(), item.DataAtualizado);

                    query.Dados.Add(dado);
                }

                query.Dados = query.Dados.OrderByDescending(x => x.Data).ToList();
                query.Dados = query.Dados.Distinct(new LocalDadosObjectDateComparer()).ToList();

                query.LocalInformacoes = new List<LocalInformacoes>();
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