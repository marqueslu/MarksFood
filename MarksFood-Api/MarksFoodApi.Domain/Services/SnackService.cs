using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Services
{
    public class SnackService
    {
        private readonly ISnackRepository _snackRepository;
        public RegisterAndUpdateOutput Create(SnackInput command)
        {
            var snack = new Snack(command.Name);

            foreach (var ingredient in command.Ingredients)
            {
                snack.AddIngredient(new Ingredient(ingredient.Name, ingredient.Price));
            }

            _snackRepository.Save(snack);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Snack registered with success.",
                Data = snack
            };
        }

        public RegisterAndUpdateOutput Update(SnackInput snackInput)
        {
            var snack = _snackRepository.GetById(snackInput.Id);

            if (snack == null)
            {
                return null;
            }

            snack.update(snack.Name);

            foreach (var ingredient in snack.Ingredients)
            {
                snack.AddIngredient(new Ingredient(ingredient.Name, ingredient.Price));
            }

            _snackRepository.Update(snack);

            return new RegisterAndUpdateOutput
            {
                Success = true,
                Message = "Snack updated with success.",
                Data = snack
            };
        }
    }
}
