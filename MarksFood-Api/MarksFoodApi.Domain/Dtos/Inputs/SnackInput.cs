using System;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Commands.Inputs
{
    public class SnackInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public IEnumerable<IngredientInput> Ingredients { get; set; }
    }
}
