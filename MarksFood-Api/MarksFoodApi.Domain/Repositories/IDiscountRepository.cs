using MarksFoodApi.Domain.Dtos.Outputs;
using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarksFoodApi.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Task<DiscountOutput> GetByIngredientAllowedId(Guid idIngredient);
        void Save(Discount discount);
        void Update(Discount discount);
        IEnumerable<Discount> GetAllDiscounts();
    }
}
