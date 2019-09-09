using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;

namespace MarksFoodApi.Domain.Services
{
    public class IngredientService
    {

        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public RegisterAndUpdateOutput Create(IngredientInput command)
        {
            var ingredient = new Ingredient(command.Name, command.Price);
            _ingredientRepository.Save(ingredient);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Ingredient registered with success.",
                Data = ingredient
            };
        }

        public RegisterAndUpdateOutput Update(IngredientInput command)
        {
            var ingredient = _ingredientRepository.GetById(command.Id);

            if (ingredient == null)
            {
                return null;
            }

            ingredient.Update(command.Name, command.Price);

            _ingredientRepository.Update(ingredient);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Ingredient updated with success.",
                Data = ingredient
            };
        }
    }
}
