using Newtonsoft.Json;

namespace APS8_CSHARP_API.Domain.Objects
{
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public decimal Pressure { get; set; }
        public decimal Sea_level { get; set; }
        public decimal Grnd_level { get; set; }
        public decimal Humidity { get; set; }
        public double Temp_kf { get; set; }
    }

    public class Weather
    {
        public decimal Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class Clouds
    {
        public decimal All { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public decimal Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; } = string.Empty;
    }

    public class List
    {
        public decimal Dt { get; set; }
        public Main Main { get; set; } = new();
        public List<Weather> Weather { get; set; } = new();
        public Clouds Clouds { get; set; } = new();
        public Wind Wind { get; set; } = new();
        public decimal Visibility { get; set; }
        public decimal Pop { get; set; }
        public Sys Sys { get; set; } = new();
        public string Dt_txt { get; set; } = string.Empty;
    }

    public class City
    {
        public decimal Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Coord Coord { get; set; } = new();
        public string Country { get; set; } = string.Empty;
        public decimal Population { get; set; }
        public decimal Timezone { get; set; }
        public decimal Sunrise { get; set; }
        public decimal Sunset { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}