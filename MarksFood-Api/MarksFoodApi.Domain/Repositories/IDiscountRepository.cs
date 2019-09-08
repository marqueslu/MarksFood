using MarksFoodApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarksFoodApi.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Discount GetByIngredientId(Guid idIngredient);
        void Save(Discount discount);
        void Update(Discount discount);
        IEnumerable<Discount> GetAllDiscounts();
    }
}
