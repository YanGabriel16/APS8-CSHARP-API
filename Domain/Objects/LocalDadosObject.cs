namespace APS8_CSHARP_API.Domain.Objects
{
    public class LocalDadosObject
    {
        public LocalDadosObject(OpenWeatherResponse clima, DateTime data)
        {
            this.Clima = clima;
            this.Data = data;
        }

        public OpenWeatherResponse Clima { get; set; }
        public DateTime Data { get; set; }
    }
}