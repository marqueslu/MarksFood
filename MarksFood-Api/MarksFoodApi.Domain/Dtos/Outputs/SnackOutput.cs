using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarksFoodApi.Domain.Commands.Results
{
    public class SnackOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IngredientOutput> Ingredients { get; set; }
        public float? Price { get; set; }

        public void Total()
        {
            Price = Ingredients.Sum(x => x.Price * x.Quantity);
        }

        public void ApplyDiscount(float discount)
        {
            Price = Price * (discount / 100);
        }
    }
}
