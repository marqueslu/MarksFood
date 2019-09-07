using MarksFoodApi.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarksFoodApi.Domain.Entities
{
    public class Snack : Entity
    {
        private readonly IList<Ingredient> _ingredients;

        protected Snack()
        {

        }

        public Snack(string name)
        {
            Name = name;
            _ingredients = new List<Ingredient>();
        }

        public string Name { get; private set; }
        public ICollection<Ingredient> Ingredients => _ingredients.ToArray();

        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

    }
}
