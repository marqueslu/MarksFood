using System;

namespace MarksFoodApi.Domain.Entities.Base
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}
