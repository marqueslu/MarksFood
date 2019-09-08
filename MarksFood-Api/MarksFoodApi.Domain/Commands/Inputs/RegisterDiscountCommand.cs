using MarksFoodApi.Domain.Enums;
using MarksFoodApi.Shared.Commands;
using System;


namespace MarksFoodApi.Domain.Commands.Inputs
{
    class RegisterDiscountCommand : ICommand
    {
        public Guid ingredientAllowed { get; set; }
        public Guid? ingredientNotAllowed { get; set; }
        public EDiscountRule discountRule { get; set; }
        public bool active { get; set; }
        public int? quantity { get; set; }
        public decimal discountPercent { get; set; }
    }
}
