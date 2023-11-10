using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Objects;

namespace APS8_CSHARP_API.Domain.Helpers
{
    public class LocalDadosObjectDateComparer : IEqualityComparer<LocalDadosObject>
    {
        public bool Equals(LocalDadosObject x, LocalDadosObject y)
        {
            if (x != null && y != null &&
                x.Data.Year == y.Data.Year &&
                x.Data.Month == y.Data.Month &&
                x.Data.Day == y.Data.Day &&
                x.Data.Hour == y.Data.Hour &&
                x.Data.Minute == y.Data.Minute)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(LocalDadosObject obj)
        {
            return obj.Data.Year.GetHashCode() ^
                   obj.Data.Month.GetHashCode() ^
                   obj.Data.Day.GetHashCode() ^
                   obj.Data.Hour.GetHashCode() ^
                   obj.Data.Minute.GetHashCode();
        }
    }

    public class LocalInformacoesDateComparer : IEqualityComparer<LocalInformacoes>
    {
        public bool Equals(LocalInformacoes x, LocalInformacoes y)
        {
            if (x != null && y != null &&
                x.DataAtualizado.Year == y.DataAtualizado.Year &&
                x.DataAtualizado.Month == y.DataAtualizado.Month &&
                x.DataAtualizado.Day == y.DataAtualizado.Day &&
                x.DataAtualizado.Hour == y.DataAtualizado.Hour &&
                x.DataAtualizado.Minute == y.DataAtualizado.Minute)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(LocalInformacoes obj)
        {
            return obj.DataAtualizado.Year.GetHashCode() ^
                   obj.DataAtualizado.Month.GetHashCode() ^
                   obj.DataAtualizado.Day.GetHashCode() ^
                   obj.DataAtualizado.Hour.GetHashCode() ^
                   obj.DataAtualizado.Minute.GetHashCode();
        }
    }
}