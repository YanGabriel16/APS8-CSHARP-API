namespace APS8_CSHARP_API.Domain.Objects
{
    public class Color
    {
        public double? Red { get; set; }
        public double? Green { get; set; }
        public double? Blue { get; set; }
    }

    public class Index
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public int Aqi { get; set; }
        public string AqiDisplay { get; set; }
        public Color Color { get; set; }
        public string Category { get; set; }
        public string DominantPollutant { get; set; }
    }

    public class Concentration
    {
        public double Value { get; set; }
        public string Units { get; set; }
    }

    public class AdditionalInfo
    {
        public string Sources { get; set; }
        public string Effects { get; set; }
    }

    public class Pollutant
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public Concentration Concentration { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }
    }

    public class HealthRecommendations
    {
        public string GeneralPopulation { get; set; }
        public string Elderly { get; set; }
        public string LungDiseasePopulation { get; set; }
        public string HeartDiseasePopulation { get; set; }
        public string Athletes { get; set; }
        public string PregnantWomen { get; set; }
        public string Children { get; set; }
    }
}