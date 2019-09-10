using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Interfaces.Services;
using MarksFoodApi.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Services
{
    public class IngredientService : IIngredientService
    {

        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public RegisterAndUpdateOutput Create(IngredientInput ingredientInput)
        {
            var ingredient = new Ingredient(ingredientInput.Name, ingredientInput.Price);
            _ingredientRepository.Save(ingredient);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Ingredient registered with success.",
                Data = ingredient
            };
        }

        public RegisterAndUpdateOutput Update(IngredientInput ingredientInput)
        {
            var ingredient = _ingredientRepository.GetById(ingredientInput.Id);

            if (ingredient == null)
            {
                return null;
            }

            ingredient.Update(ingredientInput.Name, ingredientInput.Price);

            _ingredientRepository.Update(ingredient);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Ingredient updated with success.",
                Data = ingredient
            };
        }

        public async Task<IEnumerable<IngredientOutput>> ListIngredients()
        {
            return await _ingredientRepository.GetAllIngredients();
        }
    }
}
