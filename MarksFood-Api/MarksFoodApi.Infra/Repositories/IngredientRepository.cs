using Dapper;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarksFoodApi.Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MarksFoodApiDbContext _context;

        public IngredientRepository(MarksFoodApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientOutput>> GetAllIngredients()
        {
            return await _context.Connection.QueryAsync<IngredientOutput>("SP_Ingredient_Select", new { });
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
