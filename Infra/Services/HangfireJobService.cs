using APS8_CSHARP_API.Domain.Interfaces;

namespace APS8_CSHARP_API.Infra.Services
{
    public class HangfireJobService : IHangfireJobService
    {
        public void ApiOn()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Job :: ApiOn => Api online!");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

    }
}