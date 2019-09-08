using MarksFoodApi.Shared.Commands;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class RegisterIngredientCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
