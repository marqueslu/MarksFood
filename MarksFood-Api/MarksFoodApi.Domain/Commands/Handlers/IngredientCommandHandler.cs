using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Shared.Commands;

namespace MarksFoodApi.Domain.Commands.Handlers
{
    class IngredientCommandHandler : ICommandHandler<RegisterIngredientCommand>, ICommandHandler<UpdateIngredientCommand>
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientCommandHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public ICommandResult Handle(RegisterIngredientCommand command)
        {
            var ingredient = new Ingredient(command.Name, command.Price);
            _ingredientRepository.Save(ingredient);

            return new RegisterAndUpdateCommandResult
            {
                Success = true,
                Message = "Ingredient registered with success.",
                Data = ingredient
            };
        }

        public ICommandResult Handle(UpdateIngredientCommand command)
        {
            var ingredient = _ingredientRepository.GetById(command.Id);

            if (ingredient == null)
            {
                return null;
            }

            ingredient.Update(command.Name, command.Price);

            _ingredientRepository.Update(ingredient);

            return new RegisterAndUpdateCommandResult
            {
                Success = true,
                Message = "Ingredient updated with success.",
                Data = ingredient
            };
        }
    }
}
