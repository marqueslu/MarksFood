using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Repositories
{
    public interface ISnackRepository
    {
        void Save(Snack ingredient);
        void Update(Snack ingredient);
        Snack SnackExists(string name);
        IEnumerable<Snack> GetAllSnacks();
        Snack GetById(Guid id);
    }
}
