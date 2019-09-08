using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarksFoodApi.Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MarksFoodApiContext _context;

        public IngredientRepository(MarksFoodApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetById(Guid id)
        {
            return _context.Ingredients.Find(id);
        }

        public Ingredient IngredientExists(string name)
        {
            return _context.Ingredients.Where(x => x.Name == name).FirstOrDefault();
        }

        public void Save(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public void Update(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
