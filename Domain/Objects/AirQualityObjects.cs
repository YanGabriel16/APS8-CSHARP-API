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
        public string Code { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int Aqi { get; set; }
        public string AqiDisplay { get; set; } = string.Empty;
        public Color Color { get; set; } = new();
        public string Category { get; set; } = string.Empty;
        public string DominantPollutant { get; set; } = string.Empty;
    }

    public class Concentration
    {
        public double Value { get; set; }
        public string Units { get; set; } = string.Empty;
    }

    public class AdditionalInfo
    {
        public string Sources { get; set; } = string.Empty;
        public string Effects { get; set; } = string.Empty;
    }

    public class Pollutant
    {
        public string Code { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public Concentration Concentration { get; set; } = new();
        public AdditionalInfo AdditionalInfo { get; set; } = new();
    }

    public class HealthRecommendations
    {
        public string GeneralPopulation { get; set; } = string.Empty;
        public string Elderly { get; set; } = string.Empty;
        public string LungDiseasePopulation { get; set; } = string.Empty;
        public string HeartDiseasePopulation { get; set; } = string.Empty;
        public string Athletes { get; set; } = string.Empty;
        public string PregnantWomen { get; set; } = string.Empty;
        public string Children { get; set; } = string.Empty;
    }
}