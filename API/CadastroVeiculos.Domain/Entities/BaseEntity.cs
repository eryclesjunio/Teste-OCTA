using System;

namespace CadastroVeiculos.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime DataCriacao { get; set; }
        public Guid Id { get; set; }
    }
}
