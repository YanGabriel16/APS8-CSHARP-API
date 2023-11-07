namespace APS8_CSHARP_API.Domain.Objects
{
    public class LocalDadosObject
    {
        public LocalDadosObject(AirQualityResponse qualidadeAr, OpenWeatherResponse clima, DateTime data)
        {
            this.QualidadeAr = qualidadeAr;
            this.Clima = clima;
            this.Data = data;
        }

        public AirQualityResponse QualidadeAr { get; set; }
        public OpenWeatherResponse Clima { get; set; }
        public DateTime Data { get; set; }
    }
}