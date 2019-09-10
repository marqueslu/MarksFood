using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Repositories
{
    public interface ISnackRepository
    {
        Task Save(Snack ingredient);
        Task Update(Snack ingredient);
        Snack SnackExists(string name);
        Task<IEnumerable<SnackOutput>> GetAllSnacks();
        Task<Snack> GetById(Guid id);
        Task<IEnumerable<IngredientOutput>> GetSnackIngredients(Guid idSnack);
        Task UpdateSnackIngredients(Snack snack);
        Task SaveSnackIngredients(Snack snack);

    }
}
