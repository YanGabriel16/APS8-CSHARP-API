namespace APS8_CSHARP_API.Domain.Entidades
{
    public class LocalInformacoes : BaseEntity
    {
        public string ClimaticosJson { get; set; } = string.Empty;        
        public int LocalId { get; set; }
    }
}