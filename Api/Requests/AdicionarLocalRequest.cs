namespace APS8_CSHARP_API.Api.Requests
{
    public class AdicionarLocalRequest
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
    }
}