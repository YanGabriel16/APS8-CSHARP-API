namespace APS8_CSHARP_API.Domain.Objects
{
    public class LocalDadosObject
    {
        public LocalDadosObject(AirQualityResponse qualidadeAr, OpenWeatherResponse clima)
        {
            this.QualidadeAr = qualidadeAr;
            this.Clima = clima;
        }

        public AirQualityResponse QualidadeAr { get; set; }
        public OpenWeatherResponse Clima { get; set; }
    }
}