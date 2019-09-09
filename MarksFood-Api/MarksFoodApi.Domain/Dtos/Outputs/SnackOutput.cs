using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class SnackOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
