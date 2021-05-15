using System;

namespace Desafio.Domain.Domain.Shared
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity(Guid id)
        {
            Id = id;
        }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
