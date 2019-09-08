using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Repositories
{
    public interface ISnackRepository
    {
        void Save(Snack ingredient);
        void Update(Snack ingredient);
        bool SnackExists(string name);
        IEnumerable<Snack> GetAllIngredients();
        Snack GetById(Guid id);
    }
}
