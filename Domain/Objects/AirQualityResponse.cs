namespace APS8_CSHARP_API.Domain.Objects
{
    public class AirQualityResponse
    {
        public DateTime DateTime { get; set; }
        public string RegionCode { get; set; }
        public List<Index> Indexes { get; set; }
        public List<Pollutant> Pollutants { get; set; }
        public HealthRecommendations HealthRecommendations { get; set; }
    }
}