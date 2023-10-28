using System.ComponentModel.DataAnnotations;
using APS8_CSHARP_API.Domain.Enums;

namespace APS8_CSHARP_API.Domain.Entidades
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Ativo;
        public DateTime DataCriado { get; set; } = DateTime.Now;
        public DateTime DataAtualizado { get; set; } = DateTime.Now;
    }
}