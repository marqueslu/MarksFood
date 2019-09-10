using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Interfaces.Services
{
    public interface IIngredientService
    {
        RegisterAndUpdateOutput Create(IngredientInput ingredientInput);
        RegisterAndUpdateOutput Update(IngredientInput ingredientInput);
        Task<IEnumerable<IngredientOutput>> ListIngredients();
    }
}
