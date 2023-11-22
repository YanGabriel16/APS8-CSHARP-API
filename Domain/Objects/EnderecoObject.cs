namespace APS8_CSHARP_API.Domain.Objects
{
    public class EnderecoObject
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}