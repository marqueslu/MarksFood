using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Repositories
{
    public interface IIngredientRepository
    {
        void Save(Ingredient ingredient);
        void Update(Ingredient ingredient);
        Ingredient IngredientExists(string name);
        Task<IEnumerable<IngredientOutput>> GetAllIngredients();
        Ingredient GetById(Guid id);
    }
}
