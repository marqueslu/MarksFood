using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Shared.Entities
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
