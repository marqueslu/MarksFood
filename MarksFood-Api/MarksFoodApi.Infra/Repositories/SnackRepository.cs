using Dapper;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MarksFoodApi.Infra.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly MarksFoodApiDbContext _context;

        public SnackRepository(MarksFoodApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SnackOutput>> GetAllSnacks()
        {
            var snacks = await _context.Connection.QueryAsync<SnackOutput>("SP_Snack_Select", new { });

            return snacks;
        }

        public async Task<Snack> GetById(Guid id)
        {
            var snack = await _context.Connection.QueryAsync<Snack>("SP_Get_Snack_ById", new { Id = id });
            return snack.FirstOrDefault();
        }

        public async Task Save(Snack snack)
        {
            await _context.Connection.ExecuteAsync("SP_Snack_Insert", new
            {
                Id = snack.Id,
                Name = snack.Name
            }, commandType: CommandType.StoredProcedure);
        }

        public Snack SnackExists(string name)
        {
            return _context.Connection.Query<Snack>("", new { Name = name }).FirstOrDefault();
        }

        public async Task Update(Snack snack)
        {
            await _context.Connection.ExecuteAsync("SP_Snack_Update", new
            {
                Id = snack.Id,
                Name = snack.Name
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveSnackIngredients(Snack snack)
        {
            foreach (var snackIngredient in snack.Ingredients)
            {
                await _context.Connection.ExecuteAsync("SP_SnackIngredient_Insert", new
                {
                    IdIngredient = snackIngredient.Id,
                    IdSnack = snack.Id,
                    Quantity = snackIngredient.Quantity
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateSnackIngredients(Snack snack)
        {
            foreach (var snackIngredient in snack.Ingredients)
            {
                await _context.Connection.ExecuteAsync("SP_SnackIngredient_Update", new
                {
                    IdIngredient = snackIngredient.Id,
                    IdSnack = snack.Id,
                    Quantity = snackIngredient.Quantity
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<IngredientOutput>> GetSnackIngredients(Guid idSnack)
        {
            return await _context.Connection.QueryAsync<IngredientOutput>("SP_SnackIngredients_Select", new
            {
                IdSnack = idSnack
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
