using MarksFoodApi.Shared.Commands;
using System;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class UpdateSnackCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<RegisterIngredientCommand> Ingredients { get; set; }
    }
}
