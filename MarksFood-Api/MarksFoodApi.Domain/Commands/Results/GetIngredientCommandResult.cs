using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class GetIngredientCommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
