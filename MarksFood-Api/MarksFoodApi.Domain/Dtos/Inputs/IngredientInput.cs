using System;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class IngredientInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
