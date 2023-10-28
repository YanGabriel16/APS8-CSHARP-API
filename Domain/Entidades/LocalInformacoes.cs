using System.ComponentModel.DataAnnotations.Schema;

namespace APS8_CSHARP_API.Domain.Entidades
{
    public class LocalInformacoes : BaseEntity
    {
        public string ClimaticosJson { get; set; } = string.Empty;
        public string QualidadeArJson { get; set; } = string.Empty;
        
        [ForeignKey("LocalId")]
        public int LocalId { get; set; }
    }
}