using System.ComponentModel.DataAnnotations.Schema;
using APS8_CSHARP_API.Domain.Objects;

namespace APS8_CSHARP_API.Domain.Entidades
{
    public class Local : BaseEntity
    {
        public Local(string nome, decimal longitude, decimal latitude) 
        {
            this.Nome = nome;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        
        public string Nome { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }

        [NotMapped]
        public List<LocalDadosObject> Dados { get; set; } = new();
    }
}