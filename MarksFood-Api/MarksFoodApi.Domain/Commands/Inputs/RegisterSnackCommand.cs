using MarksFoodApi.Shared.Commands;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class RegisterSnackCommand : ICommand
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<RegisterIngredientCommand> Ingredients { get; set; }
    }
}
