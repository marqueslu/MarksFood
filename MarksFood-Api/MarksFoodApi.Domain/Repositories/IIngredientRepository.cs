using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Repositories
{
    public interface IIngredientRepository
    {
        void Save(Ingredient ingredient);
        void Update(Ingredient ingredient);
        Ingredient IngredientExists(string name);
        IEnumerable<Ingredient> GetAllIngredients();
        Ingredient GetById(Guid id);
    }
}
