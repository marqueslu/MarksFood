using MarksFoodApi.Domain.Commands.Inputs;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Enums;
using MarksFoodApi.Domain.Interfaces.Services;
using MarksFoodApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Services
{
    public class SnackService : ISnackService
    {
        private readonly ISnackRepository _snackRepository;
        private readonly IDiscountRepository _discountRepository;

        public SnackService(ISnackRepository snackRepository, IDiscountRepository discountRepository)
        {
            _snackRepository = snackRepository;
            _discountRepository = discountRepository;
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

        public async Task<IEnumerable<SnackOutput>> GetAllSnacks()
        {
            var snacks = await _snackRepository.GetAllSnacks();

            foreach (var snack in snacks)
            {
                snack.Ingredients = await _snackRepository.GetSnackIngredients(snack.Id);

                foreach (var snackIngredient in snack.Ingredients)
                {
                    snackIngredient.Total();
                    var discount = await _discountRepository.GetByIngredientAllowedId(snackIngredient.Id);

                    if (discount != null)
                    {
                        if (discount.DiscountRule == EDiscountRule.RestrictionBased)
                        {
                            var existsSnackNotAllowed = snack.Ingredients.Where(x => x.Id == discount.IdIngredientNotAllowed);

                            if (existsSnackNotAllowed == null)
                                snackIngredient.ApplyDiscount(discount.Percent);
                        }
                        else if (discount.DiscountRule == EDiscountRule.QuantityBased && snackIngredient.Quantity >= discount.Quantity)
                        {
                            snackIngredient.ApplyDiscount(discount.Percent);
                        }
                    }
                }

                snack.Total();
            }

            return snacks;

        }
    }
}
