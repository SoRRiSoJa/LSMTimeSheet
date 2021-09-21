using FluentValidator;
using System;

namespace TimeSheet.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            IsAtivo = true;
        }
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
