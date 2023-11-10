using Newtonsoft.Json;

namespace APS8_CSHARP_API.Domain.Helpers
{
    public class Constants
    {
        public static string ConnectionString { get => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APS8-db;Integrated Security=True"; }
        public static JsonSerializerSettings jsonSettings { get => new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }; }
    }
}