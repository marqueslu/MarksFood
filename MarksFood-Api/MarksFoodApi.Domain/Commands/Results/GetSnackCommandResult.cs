using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class GetSnackCommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
