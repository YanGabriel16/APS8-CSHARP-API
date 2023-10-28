namespace APS8_CSHARP_API.Domain.Extensions
{
    public class CronExtensions
    {
        /// <summary>
        /// Retorna uma expressao cron que será executado a cada 'N' minutos.
        /// <para>
        /// Sendo o parametro min a quantidade de minutos.
        /// </para>
        /// </summary>
        /// <returns>0 */N * * * *</returns>
        public static string Minutely(int min)
        {
            if (min < 1 || min > 59)
                throw new Exception("CronExtensions :: Minutely => Os minutos devem estar entre 1 a 59");

            return $"0 */{min} * * * *";
        }
    }
}