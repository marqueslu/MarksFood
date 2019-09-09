using Dapper;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarksFoodApi.Infra.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly MarksFoodApiDbContext _context;

        public SnackRepository(MarksFoodApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SnackOutput> GetAllSnacks()
        {
            var snacks = _context.Connection.Query<SnackOutput>("SELECT [Id], [Name] FROM [Snack]", new { });

            foreach (var snack in snacks)
            {
                snack.Ingredients = GetSnackIngredients(snack.Id);
            }

            return snacks;
        }

        public Snack GetById(Guid id)
        {
            var snack = _context.Connection.Query<Snack>("SELECT [Id], [Name] FROM [Snack] WHERE Id = @Id", new { Id = id }).FirstOrDefault();            
            return snack;
        }

        public void Save(Snack snack)
        {
            _context.Connection.Execute("SP_Snack_Insert", new
            {
                Id = snack.Id,
                Name = snack.Name
            }, commandType: CommandType.StoredProcedure);
        }

        public Snack SnackExists(string name)
        {
            return _context.Connection.Query<Snack>("SELECT [Id], [Name] FROM [Snack] WHERE Name = @Name", new { Name = name }).FirstOrDefault();
        }

        public void Update(Snack snack)
        {
            _context.Connection.Execute("SP_Snack_Update", new
            {
                Id = snack.Id,
                Name = snack.Name
            }, commandType: CommandType.StoredProcedure);
        }

        public void SaveSnackIngredients(Snack snack)
        {
            foreach (var snackIngredient in snack.Ingredients)
            {
                _context.Connection.Execute("SP_SnackIngredient_Insert", new
                {
                    IdIngredient = snackIngredient.Id,
                    IdSnack = snack.Id,
                    Quantity = snackIngredient.Quantity
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateSnackIngredients(Snack snack)
        {
            foreach (var snackIngredient in snack.Ingredients)
            {
                _context.Connection.Execute("SP_SnackIngredient_Update", new
                {
                    IdIngredient = snackIngredient.Id,
                    IdSnack = snack.Id,
                    Quantity = snackIngredient.Quantity
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Ingredient> GetSnackIngredients(Guid idSnack)
        {
            return _context.Connection.Query<Ingredient>("SP_SnackIngredients_Select", new
            {
                IdSnack = idSnack
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
