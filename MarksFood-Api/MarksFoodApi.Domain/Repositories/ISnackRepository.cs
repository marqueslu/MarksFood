using MarksFoodApi.Domain.Commands.Results;
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
        IEnumerable<SnackOutput> GetAllSnacks();
        Snack GetById(Guid id);
        IEnumerable<Ingredient> GetSnackIngredients(Guid idSnack);
    }
}
