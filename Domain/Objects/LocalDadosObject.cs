namespace APS8_CSHARP_API.Domain.Objects
{
    public class LocalDadosObject
    {
        public LocalDadosObject(List<AirQualityResponse> qualidadeAr, List<OpenWeatherResponse> climaticos)
        {
            this.QualidadeAr = qualidadeAr;
            this.Climaticos = climaticos;
        }

        public List<AirQualityResponse> QualidadeAr { get; set; }
        public List<OpenWeatherResponse> Climaticos { get; set; }
    }
}