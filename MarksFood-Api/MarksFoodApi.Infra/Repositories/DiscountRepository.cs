using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarksFoodApi.Domain.Dtos.Outputs;
using MarksFoodApi.Domain.Entities;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Infra.Context;

namespace MarksFoodApi.Infra.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly MarksFoodApiDbContext _context;

        public DiscountRepository(MarksFoodApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            throw new NotImplementedException();
        }

        public async Task<DiscountOutput> GetByIngredientAllowedId(Guid idIngredient)
        {
            var discount = await _context.Connection.QueryAsync<DiscountOutput>(
                "SP_Discount_Select",
                new
                {
                    IdIngredientAllowed = idIngredient
                }, commandType: CommandType.StoredProcedure);

            return discount.FirstOrDefault();
        }

        public void Save(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void Update(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}
