using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarksFoodApi.Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MarksFoodApiDbContext _context;

        public IngredientRepository(MarksFoodApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Ingredient IngredientExists(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void Update(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
