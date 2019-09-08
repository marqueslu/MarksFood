using MarksFoodApi.Domain.Enums;
using MarksFoodApi.Shared.Entities;
using System;

namespace MarksFoodApi.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount()
        {

        }

        public Discount(
            string description,
            Guid ingredientAllowed,
            Guid? ingredientNotAllowed,
            EDiscountRule discountRule,
            bool active,
            int? quantity,
            decimal discountPercent)
        {
            Description = description;
            IngredientAllowed = ingredientAllowed;
            IngredientNotAllowed = ingredientNotAllowed;
            DiscountRule = discountRule;
            Active = active;
            Quantity = quantity;
            DiscountPercent = discountPercent;
        }

        public string Description { get; set; }
        public Guid IngredientAllowed { get; private set; }
        public Guid? IngredientNotAllowed { get; private set; }
        public EDiscountRule DiscountRule { get; private set; }
        public bool Active { get; private set; }
        public int? Quantity { get; private set; }
        public decimal DiscountPercent { get; private set; }
    }
}
