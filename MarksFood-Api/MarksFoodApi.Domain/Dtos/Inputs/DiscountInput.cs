using MarksFoodApi.Domain.Enums;
using System;


namespace MarksFoodApi.Domain.Commands.Inputs
{
    class DiscountInput
    {
        public Guid ingredientAllowed { get; set; }
        public Guid? ingredientNotAllowed { get; set; }
        public EDiscountRule discountRule { get; set; }
        public bool active { get; set; }
        public int? quantity { get; set; }
        public decimal discountPercent { get; set; }
    }
}
