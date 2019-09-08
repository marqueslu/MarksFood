using MarksFoodApi.Shared.Commands;
using System;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class UpdateIngredientCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
