using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Services
{
    public class SnackService
    {
        private readonly ISnackRepository _snackRepository;

        public SnackService(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public async Task<RegisterAndUpdateOutput> Create(SnackInput snackInput)
        {
            var snack = new Snack(snackInput.Name);

            foreach (var ingredient in snackInput.Ingredients)
            {
                var ingredientSnack = new Ingredient(ingredient.Name, ingredient.Price);
                ingredientSnack.AddQuantity(ingredient.Quantity);
                snack.AddIngredient(ingredientSnack);
            }

            await _snackRepository.Save(snack);
            await _snackRepository.UpdateSnackIngredients(snack);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Snack registered with success.",
                Data = snack
            };
        }

        public async Task<RegisterAndUpdateOutput> Update(SnackInput snackInput)
        {
            var snack = await _snackRepository.GetById(snackInput.Id);

            if (snack == null)
            {
                return null;
            }

            snack.update(snack.Name);

            foreach (var ingredient in snackInput.Ingredients)
            {
                var ingredientSnack = new Ingredient(ingredient.Name, ingredient.Price);
                ingredientSnack.AddQuantity(ingredient.Quantity);
                snack.AddIngredient(ingredientSnack);
            }

            await _snackRepository.Update(snack);

            await _snackRepository.UpdateSnackIngredients(snack);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Snack updated with success.",
                Data = snack
            };
        }
    }
}
