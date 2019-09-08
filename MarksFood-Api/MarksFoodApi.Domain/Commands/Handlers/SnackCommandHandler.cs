using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Shared.Commands;

namespace MarksFoodApi.Domain.Commands.Handlers
{
    public class SnackCommandHandler : ICommandHandler<RegisterSnackCommand>, ICommandHandler<UpdateSnackCommand>
    {
        private readonly ISnackRepository _snackRepository;
        public ICommandResult Handle(RegisterSnackCommand command)
        {
            var snack = new Snack(command.Name);

            foreach (var ingredient in command.Ingredients)
            {
                snack.AddIngredient(new Ingredient(ingredient.Name, ingredient.Price));
            }

            _snackRepository.Save(snack);

            return new RegisterAndUpdateCommandResult
            {
                Success = true,
                Message = "Snack registered with success.",
                Data = snack
            };
        }

        public ICommandResult Handle(UpdateSnackCommand command)
        {
            var snack = _snackRepository.GetById(command.Id);

            if (snack == null)
            {
                return null;
            }

            snack.update(command.Name);

            foreach (var ingredient in command.Ingredients)
            {
                snack.AddIngredient(new Ingredient(ingredient.Name, ingredient.Price));
            }

            _snackRepository.Update(snack);

            return new RegisterAndUpdateCommandResult
            {
                Success = true,
                Message = "Snack updated with success.",
                Data = snack
            };
        }
    }
}
